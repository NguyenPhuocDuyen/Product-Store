using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public CategorysController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        {
            return Ok(await _db.Category.GetAllAsync(includeProperties: "Products"));
        }

        // POST: api/Categorys
        [HttpPost]
        public async Task<IActionResult> PostCategory(Category category)
        {
            try
            {
                _db.Category.Add(category);
                await _db.SaveAsync();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
