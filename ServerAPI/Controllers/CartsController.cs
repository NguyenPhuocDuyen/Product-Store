using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public CartsController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return Ok(await _db.Cart.GetAllAsync());
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _db.Cart.GetFirstOrDefaultAsync(x => x.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            try
            {
                _db.Cart.Update(cart);
                await _db.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CartExists(id))
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

        // POST: api/Carts
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _db.Cart.Add(cart);
            await _db.SaveAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _db.Cart.GetFirstOrDefaultAsync(x => x.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            _db.Cart.Remove(cart);
            await _db.SaveAsync();

            return NoContent();
        }

        private async Task<bool> CartExists(int id)
        {
            var cart = await _db.Cart.GetFirstOrDefaultAsync(x => x.Id == id);
            if (cart == null)
            {
                return false;
            }
            return true;
        }

        // Khang - Post: AddProductToCart
        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddCart([FromBody] Cart cart)
        {
            var oldCart = await _db.Cart.GetFirstOrDefaultAsync(x => x.UserId == cart.UserId && x.ProductId == cart.ProductId);
            // Check cart is exist in database to create cart or upadate quantity
            if(oldCart == null)
            {
                cart.Quantity = 1;
                cart.CreateAt = DateTime.Now;
                cart.UpdateAt = DateTime.Now;
                _db.Cart.Add(cart);
                await _db.SaveAsync();
            }
            else
            {
                oldCart.Quantity += 1;
                oldCart.UpdateAt= DateTime.Now;
                _db.Cart.Update(oldCart);
                await _db.SaveAsync();
            }
            return NoContent();
        }
    }
}
