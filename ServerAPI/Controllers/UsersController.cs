using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public UsersController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _db.User.GetAllAsync());
        }

        // GET: api/Users/5s
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _db.User.GetFirstOrDefaultAsync(filter: x => x.Id == id, includeProperties: "Role");

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _db.User.Update(user);
                await _db.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var u = await _db.User.GetFirstOrDefaultAsync(
                filter: x=>x.Email.ToLower().Trim()
                .Equals(user.Email.ToLower().Trim()));
            if (u == null)
            {
                _db.User.Add(user);
                await _db.SaveAsync();
                return u;
            }

            return BadRequest(u);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _db.User.Remove(user);
            await _db.SaveAsync();

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            var user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        // POST: api/Users
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var u = await _db.User.GetFirstOrDefaultAsync(
                filter: x=>x.Email.ToLower().Trim()
                .Equals(user.Email.ToLower().Trim())
                && x.Password.ToLower().Trim()
                .Equals(user.Password.ToLower().Trim()),
                includeProperties: "Role"
                );

            if (u == null)
            {
                return NotFound();
            }
            return u;
        }
    }
}
