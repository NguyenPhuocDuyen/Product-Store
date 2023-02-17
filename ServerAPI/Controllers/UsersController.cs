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
            return Ok(await _db.User.GetAllAsync(includeProperties: "Role"));
        }

        // GET: api/Users/5
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
            _db.User.Add(user);
            await _db.SaveAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
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
    }
}
