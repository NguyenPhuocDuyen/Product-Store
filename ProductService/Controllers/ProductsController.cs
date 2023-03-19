using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using System;
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

        // GET: api/Products/GetProducts
        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok((await _db.Product.GetAllAsync(includeProperties: "Category,Reviews")).ToList());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //get product by id
            var product = await _db.Product.GetFirstOrDefaultAsync(filter: x => x.Id == id, includeProperties: "Category,Reviews");

            //check null
            if (product == null)
            {
                return NotFound(new ErrorApp { Error = ErrorContent.NotFound });
            }

            return product;
        }

        // GET: api/Products/TopSaleProductId
        [HttpGet("TopSaleProductId")]
        public async Task<ActionResult<List<int>>> GetTopSaleProductId()
        {
            //get order bought
            var order = await _db.Order.GetAllAsync(filter: x => x.StatusId == 3);
            //get all orderdetail of all product have amount > 0
            var orderDetails = await _db.OrderDetail.GetAllAsync(filter: x => x.Product.Amount > 0, includeProperties: "Product");
            //filter and take 4 top product sale 
            var data = (from obj in orderDetails
                        group obj by obj.ProductId into gr
                        let count = gr.Sum(x => x.Amount)
                        orderby count descending
                        select gr.Key.Value).Take(4).ToList();

            return data;
        }

        // GET: api/Products/AddProduct
        [Authorize(Roles = RoleContent.Admin)]
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            try
            {
                //product.UserId = 1;
                _db.Product.Add(product);
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }

        // PUT: api/Products/UpdateProduct/1
        //[Authorize(Roles = RoleContent.Admin)]
        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            //get product by id
            var pro = await _db.Product.GetFirstOrDefaultAsync(filter: x => x.Id == id);
            if (pro == null)
                return NotFound();

            //update info except image
            pro.Title = product.Title;
            pro.Description = product.Description;
            pro.RecentPrice = product.RecentPrice;
            pro.Amount = product.Amount;
            pro.CategoryId = product.CategoryId;
            pro.UpdateAt = DateTime.Now;

            //update image
            if (!string.IsNullOrEmpty(product.Thumbnail))
            {
                pro.Thumbnail = product.Thumbnail;
            }

            try
            {
                _db.Product.Update(pro);
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
