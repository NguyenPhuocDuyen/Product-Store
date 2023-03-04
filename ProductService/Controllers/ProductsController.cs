using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public ProductsController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _db.Product.GetAllAsync(includeProperties: "Category,Reviews"));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _db.Product.GetFirstOrDefaultAsync(filter: x => x.Id == id, includeProperties: "Category,Reviews");

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products
        [HttpGet("TopSaleProductId")]
        public async Task<IActionResult> GetTopSaleProductId()
        {
            //get order bought
            var order = await _db.Order.GetAllAsync(filter: x => x.StatusId == 4);
            var orderDetails = await _db.OrderDetail.GetAllAsync(includeProperties: "Product");

            var data = (from obj in orderDetails
                        group obj by obj.ProductId into gr
                        let count = gr.Sum(x => x.Amount)
                        orderby count descending
                        select gr.Key.Value).Take(4).ToList();

            return Ok(data);
        }
    }
}
