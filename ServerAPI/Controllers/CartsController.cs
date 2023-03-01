using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [HttpPut]
        public async Task<IActionResult> PutCart(Cart cart)
        {
            var c = await _db.Cart.GetFirstOrDefaultAsync(x=>x.Id == cart.Id);
            if(c == null)
            {
                return NotFound();
            }

            try
            {
                c.Quantity = cart.Quantity;
                c.UpdateAt = DateTime.Now;
                _db.Cart.Update(c);
                await _db.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CartExists(cart.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var c2 = await _db.Cart.GetFirstOrDefaultAsync(x => x.Id == cart.Id, includeProperties: "Product");
            return Ok(c2);
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
        [Authorize]
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
        [Authorize]
        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddCart([FromBody] Cart cart)
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            var oldCart = await _db.Cart.GetFirstOrDefaultAsync(x => x.UserId == user.Id && x.ProductId == cart.ProductId);
            // Check cart is exist in database to create cart or upadate quantity
            if (oldCart == null)
            {
                cart.UserId = user.Id;
                cart.Quantity = cart.Quantity ?? 1;
                cart.CreateAt = DateTime.Now;
                cart.UpdateAt = DateTime.Now;
                _db.Cart.Add(cart);
                await _db.SaveAsync();
            }
            else
            {
                if (cart.Quantity != null)
                {
                    oldCart.Quantity += cart.Quantity;
                }
                else
                {
                    oldCart.Quantity += 1;
                }
                oldCart.UpdateAt = DateTime.Now;
                _db.Cart.Update(oldCart);
                await _db.SaveAsync();
            }
            return NoContent();
        }

        // GET: api/Carts/5
        [Authorize]
        [HttpGet("GetCartsUser")]
        public async Task<ActionResult<List<Cart>>> GetCartsUser()
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            var carts = await _db.Cart.GetAllAsync(x => x.UserId == user.Id,
                includeProperties: "Product");

            if (carts == null)
            {
                return NotFound();
            }

            return carts.ToList();
        }
    }
}
