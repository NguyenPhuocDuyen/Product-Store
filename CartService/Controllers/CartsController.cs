using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Models.ViewModel;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public CartsController(IUnitOfWork db)
        {
            _db = db;
        }

        // PUT: api/Carts/5
        [HttpPut("PutCart")]
        public async Task<IActionResult> PutCart(Cart cart)
        {
            var c = await _db.Cart.GetFirstOrDefaultAsync(x => x.Id == cart.Id,
                includeProperties: "Product");
            if (c == null)
            {
                return NotFound();
            }

            try
            {
                c.Quantity = cart.Quantity;

                if (c.Quantity > c.Product.Amount)
                {
                    c.Quantity = c.Product.Amount;
                }

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

            return Ok(c);
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

            try
            {
                _db.Cart.Remove(cart);
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
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
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                string role = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                if (role == RoleContent.Admin)
                {
                    return BadRequest();
                }
            }

            var oldCart = await _db.Cart.GetFirstOrDefaultAsync(x
                => x.UserId == user.Id
                && x.ProductId == cart.ProductId,
                includeProperties: "Product");

            var product = await _db.Product.GetFirstOrDefaultAsync(x=>x.Id == cart.ProductId);

            // Check cart is exist in database to create cart or upadate quantity
            if (oldCart == null)
            {
                cart.UserId = user.Id;
                cart.Quantity = cart.Quantity ?? 1;
                cart.CreateAt = DateTime.Now;
                cart.UpdateAt = DateTime.Now;
                _db.Cart.Add(cart);
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

                bool isQuantityFull = false;
                //amount of product is max
                if (product.Amount < oldCart.Quantity)
                {
                    oldCart.Quantity = product.Amount;
                    isQuantityFull = true;
                }

                oldCart.UpdateAt = DateTime.Now;
                _db.Cart.Update(oldCart);

                if (isQuantityFull) return BadRequest();
            }

            try
            {
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Carts/5
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

        // GET: api/Carts/CheckQuantity
        [HttpGet("CheckQuantity")]
        public async Task<ActionResult> CheckQuantity()
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

            foreach (var item in carts)
            {
                if (item.Product.Amount == 0)
                {
                    _db.Cart.Remove(item);
                }
                else if (item.Quantity > item.Product.Amount)
                {
                    item.Quantity = item.Product.Amount;
                    _db.Cart.Update(item);
                }
            }

            try
            {
                await _db.SaveAsync();
                return Ok(carts);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
