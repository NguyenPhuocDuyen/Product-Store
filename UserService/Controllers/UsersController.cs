using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using Utility;
using System.Security.Cryptography;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Models.ViewModel;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration, IUnitOfWork db)
        {
            _configuration = configuration;
            _db = db;
        }

        //GET: api/Users
        [Authorize(Roles = RoleContent.Admin)]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _db.User.GetAllAsync());
        }

        //GET: api/Users
        [HttpGet("TotalUser")]
        public async Task<ActionResult<int>> TotalUser()
        {
            var list = await _db.User.GetAllAsync();
            return Ok(list.Count());
        }

        // GET: api/Users/5s
        [Authorize]
        [HttpGet("GetUserInfo")]
        public async Task<ActionResult<User>> GetUserInfo()
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost("PostUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var u = await _db.User.GetFirstOrDefaultAsync(
                filter: x => x.Email.ToLower().Trim()
                .Equals(user.Email.ToLower().Trim()));

            if (u == null)
            {
                try
                {
                    // Tạo mã xác thực
                    byte[] randomBytes = new byte[32];
                    using (RNGCryptoServiceProvider rng = new())
                    {
                        rng.GetBytes(randomBytes);
                    }
                    string token = BitConverter.ToString(randomBytes).Replace("-", "").ToLower();

                    user.RoleId = 2;
                    user.Password = HasPassword.HashPassword(user.Password);

                    //xác thực mail
                    user.EmailConfirmationToken = token;
                    user.EmailConfirmationSentAt = DateTime.Now;
                    user.EmailConfirmed = false;

                    _db.User.Add(user);
                    await _db.SaveAsync();

                    //send mail to confirm account
                    try
                    {
                        MailContent mailContent = new MailContent()
                        {
                            To = user.Email,
                            Subject = "Kích hoạt tài khoản TKDecor",
                            Body = $"<h4>Bạn đã tạo tài khoản cho web TKDecor </h4><p>Vui lòng click vào <a href=\"https://localhost:44310/Account/Login?tokenMail=" + token + "\">đây</a> để kích hoạt tài khoản của bạn.</p>"
                        };

                        HttpResponseMessage response = GobalVariables.WebAPIClient.PostAsJsonAsync($"Mails/PostMail", mailContent).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            return u;
                        }
                    }
                    catch { }

                    return u;
                }
                catch { }
            }

            return BadRequest();
        }

        // POST: api/Users
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var u = await _db.User.GetFirstOrDefaultAsync(
                filter: x => x.Email.ToLower().Trim()
                .Equals(user.Email.ToLower().Trim()), 
                includeProperties: "Role");

            if (u == null) return NotFound();

            bool isCorrectPassword = HasPassword.CheckPassword(user.Password, u.Password);

            if (!isCorrectPassword)
                return BadRequest(new { message = "Password not correct" });

            if (!u.EmailConfirmed) return BadRequest("Email chưa xác nhận");

            //tao handler
            var tokenHandler = new JwtSecurityTokenHandler();
            //encoding key in json
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            //set description for token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, u.Id.ToString()),
                    new Claim(ClaimTypes.Role, u.Role.Description.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //create token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //convert token to string
            var tokenString = tokenHandler.WriteToken(token);
            u.Password = tokenString;

            return u;
        }

        //update user info
        [Authorize]
        [HttpPost("UpdateInfoUser")]
        public async Task<IActionResult> UpdateInfoUser(User userInput)
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }
            if (string.IsNullOrEmpty(userInput.Password))
            {
                //update user info not pass
                user.FullName = userInput.FullName;
                user.Phone = userInput.Phone;
                user.Address = userInput.Address;
            }
            else
            {
                user.Password = userInput.Password;
            }
            user.UpdateAt = DateTime.Now;

            try
            {
                _db.User.Update(user);
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        //confirm mail user info
        [HttpPost("ConfirmMail")]
        public async Task<IActionResult> ConfirmMail(User userInput)
        {
            var user = await _db.User.GetFirstOrDefaultAsync(x => x.EmailConfirmationToken == userInput.EmailConfirmationToken);

            if (user == null) return NotFound();

            user.EmailConfirmed = true;

            try
            {
                _db.User.Update(user);
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
