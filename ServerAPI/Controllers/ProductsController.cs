using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ServerAPI.Controllers
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
            return Ok(await _db.Product.GetAllAsync());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _db.Product.GetFirstOrDefaultAsync(filter: x=>x.Id == id, includeProperties: "Category,User");

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _db.Product.Update(product);
                await _db.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(id))
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

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> Product(Product product)
        {
            _db.Product.Add(product);
            await _db.SaveAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product =await _db.Product.GetFirstOrDefaultAsync(x=>x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Product.Remove(product);
            await _db.SaveAsync();

            return NoContent();
        }

        private async Task<bool> ProductExists(int id)
        {
            var product =await _db.Product.GetFirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            return true;
        }

        // GET: api/Products
        [HttpGet("TopSaleProductId")]
        public async Task<ActionResult<IEnumerable<Product>>> GetTopSaleProducts()
        {
            //get order bought
            var order = await _db.Order.GetAllAsync(filter: x => x.StatusId == 4);
            var orderDetails = await _db.OrderDetail.GetAllAsync();
            //get orderDetails bought
            orderDetails = orderDetails.Join(order, or => or.OrderId, ord => ord.Id, (or, ord) => or);

            var idP = (from obj in orderDetails
                       group obj by obj.ProductId into gr
                       let count = gr.Sum(x => x.Amount)
                       orderby count descending
                       select gr.Key)
                       .Take(4);

            var products = await _db.Product.GetAllAsync();
            products = products.Where(x => idP.Contains(x.Id));

            return Ok(idP);
        }
    }
}
