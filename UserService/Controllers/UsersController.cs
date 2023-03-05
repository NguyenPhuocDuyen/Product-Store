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
        [Authorize(Roles = "Admin")]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _db.User.GetAllAsync());
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
                user.RoleId = 2;
                _db.User.Add(user);
                await _db.SaveAsync();
                return u;
            }

            return BadRequest(u);
        }

        // POST: api/Users
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var u = await _db.User.GetFirstOrDefaultAsync(
                filter: x => x.Email.ToLower().Trim()
                .Equals(user.Email.ToLower().Trim())
                && x.Password.ToLower().Trim()
                .Equals(user.Password.ToLower().Trim()),
                includeProperties: "Role"
                );

            if (u == null)
                return BadRequest(new { message = "Username or password is incorrect" });

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
    }
}
