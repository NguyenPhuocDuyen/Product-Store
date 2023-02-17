using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public CategorysController(IUnitOfWork db) {
            _db = db;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        {
            return Ok(await _db.Category.GetAllAsync());
        }

        // GET: api/Categorys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _db.Category.GetFirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categorys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                _db.Category.Update(category);
                await _db.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
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

        // POST: api/Categorys
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _db.Category.Add(category);
            await _db.SaveAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categorys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _db.Category.GetFirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _db.Category.Remove(category);
            await _db.SaveAsync();

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            var category = await _db.Category.GetFirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return false;
            }
            return true;
        }
    }
}
