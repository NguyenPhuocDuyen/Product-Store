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

        //GET: api/Users/GetUsers
        [Authorize(Roles = RoleContent.Admin)]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _db.User.GetAllAsync());
        }

        //GET: api/Users/TotalUser
        [HttpGet("TotalUser")]
        public async Task<ActionResult<int>> TotalUser()
        {
            var list = await _db.User.GetAllAsync();
            return Ok(list.Count());
        }

        // GET: api/Users/GetUserInfo
        [Authorize]
        [HttpGet("GetUserInfo")]
        public async Task<ActionResult<User>> GetUserInfo()
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // get user by user id
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            return user;
        }

        // POST: api/Users/PostUser
        //user register accoount
        [HttpPost("PostUser")]
        public async Task<ActionResult> PostUser(User user)
        {
            //get user in database by email
            var u = await _db.User.GetFirstOrDefaultAsync(
                filter: x => x.Email.ToLower().Trim()
                .Equals(user.Email.ToLower().Trim()));

            //check null
            if (u == null)
            {
                try
                {
                    // create code authen email
                    byte[] randomBytes = new byte[32];
                    using (RNGCryptoServiceProvider rng = new())
                    {
                        rng.GetBytes(randomBytes);
                    }
                    string token = BitConverter.ToString(randomBytes).Replace("-", "").ToLower();

                    //register role of user: 2 = Customer
                    user.RoleId = 2;
                    user.Password = HasPassword.HashPassword(user.Password);

                    //property authen mail
                    user.EmailConfirmationToken = token;
                    user.EmailConfirmationSentAt = DateTime.Now;
                    user.EmailConfirmed = false;

                    //add to database
                    _db.User.Add(user);
                    await _db.SaveAsync();

                    //send mail to confirm account
                    //set data to send
                    MailContent mailContent = new()
                    {
                        To = user.Email,
                        Subject = "Kích hoạt tài khoản TKDecor Shop",
                        Body = $"<h4>Bạn đã tạo tài khoản cho web TKDecor </h4><p>Vui lòng click vào <a href=\"https://localhost:44310/Account/Login?tokenMail=" + token + "\">đây</a> để kích hoạt tài khoản của bạn.</p>"
                    };

                    //send mail
                    HttpResponseMessage response = GobalVariables.WebAPIClient.PostAsJsonAsync($"Mails/PostMail", mailContent).Result;
                    //check status
                    if (response.IsSuccessStatusCode)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest(new ErrorApp { Error = ErrorContent.SendEmail });
                    }
                }
                catch { }
            }

            //lỗi do xung đột dữ liệu cụ thể là trùng email
            return Conflict(new ErrorApp { Error = ErrorContent.EmailExists });
        }

        // POST: api/Users/Login
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(User user)
        {
            //get user by email in database
            var u = await _db.User.GetFirstOrDefaultAsync(
                filter: x => x.Email.ToLower().Trim()
                .Equals(user.Email.ToLower().Trim()),
                includeProperties: "Role");

            //check user null
            if (u == null) return NotFound(new ErrorApp { Error = ErrorContent.LoginFail });

            //check confirm email
            if (!u.EmailConfirmed) return BadRequest(new ErrorApp { Error = ErrorContent.NotConfirmEmail });

            //check correct password
            bool isCorrectPassword = HasPassword.CheckPassword(user.Password, u.Password);
            if (!isCorrectPassword)
                return BadRequest(new ErrorApp { Error = ErrorContent.LoginFail });

            //create handler
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

            return Ok(new { User = u, Access_Token = tokenString });
        }

        // POST: api/Users/UpdateInfoUser
        //update user info
        [Authorize]
        [HttpPost("UpdateInfoUser")]
        public async Task<ActionResult> UpdateInfoUser(User userInput)
        {
            User user = new();
            //get user by token
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // get user by id
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            //update orther info except password
            if (string.IsNullOrEmpty(userInput.Password))
            {
                //update user info not pass
                user.FullName = userInput.FullName;
                user.Phone = userInput.Phone;
                user.Address = userInput.Address;
            }
            else
            {
                //update password
                user.Password = HasPassword.HashPassword(userInput.Password);
            }
            user.UpdateAt = DateTime.Now;

            try
            {
                //update database
                _db.User.Update(user);
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }

        // POST: api/Users/ConfirmMail
        //confirm mail of user 
        [HttpPost("ConfirmMail")]
        public async Task<ActionResult> ConfirmMail(User userInput)
        {
            // get user by email confirm token 
            var user = await _db.User.GetFirstOrDefaultAsync(x => x.EmailConfirmationToken == userInput.EmailConfirmationToken);

            if (user == null) return NotFound(new ErrorApp { Error = ErrorContent.UserNotFound });

            //set email confirm
            user.EmailConfirmed = true;

            try
            {
                //update database
                _db.User.Update(user);
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }
    }
}
