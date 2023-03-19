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

        // PUT: api/Carts/PutCart
        [HttpPut("PutCart")]
        public async Task<ActionResult<Cart>> PutCart(Cart cart)
        {
            //get cart by id
            var cartDB = await _db.Cart.GetFirstOrDefaultAsync(x => x.Id == cart.Id,
                includeProperties: "Product");

            if (cartDB == null) return NotFound(new ErrorApp { Error = ErrorContent.NotFound });

            //update cart
            try
            {
                //compare quantiy in cart with amount of product
                if (cart.Quantity > cartDB.Product.Amount)
                {
                    cartDB.Quantity = cartDB.Product.Amount;
                }
                else
                {
                    cartDB.Quantity = cart.Quantity;
                }

                cartDB.UpdateAt = DateTime.Now;
                _db.Cart.Update(cartDB);
                await _db.SaveAsync();
                return cartDB;
            }
            catch
            {
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCart(int id)
        {
            //get cart by id
            var cart = await _db.Cart.GetFirstOrDefaultAsync(x => x.Id == id);
            if (cart == null)
                return NotFound(new ErrorApp { Error = ErrorContent.NotFound });

            try
            {
                _db.Cart.Remove(cart);
                await _db.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }

        // Post: api/Carts/AddProductToCart
        [HttpPost("AddProductToCart")]
        public async Task<ActionResult> AddCart([FromBody] Cart cart)
        {
            User user = new();
            //get current user info
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // get  user by id
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            //check role admin -- admin not accecpt this action
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                string role = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                if (role == RoleContent.Admin)
                    return BadRequest(new ErrorApp { Error = ErrorContent.NotAllow });
            }

            //get old cart of user
            var oldCart = await _db.Cart.GetFirstOrDefaultAsync(x
                => x.UserId == user.Id
                && x.ProductId == cart.ProductId,
                includeProperties: "Product");

            //get product have in cart
            var product = await _db.Product.GetFirstOrDefaultAsync(x => x.Id == cart.ProductId);

            //check quantity full in product
            bool isQuantityFull = false;

            // Check cart is exist in database to create cart or upadate quantity
            if (oldCart == null)
            {
                cart.UserId = user.Id;
                if (cart.Quantity is null)
                {
                    cart.Quantity = 1;
                }
                else if (cart.Quantity > product.Amount)
                {
                    isQuantityFull = true;
                    cart.Quantity = product.Amount;
                }
                cart.CreateAt = DateTime.Now;
                cart.UpdateAt = DateTime.Now;
                _db.Cart.Add(cart);
            }
            else
            {
                //users have data transmission quantity?
                if (cart.Quantity == null)
                {
                    oldCart.Quantity += 1;
                }
                else
                {
                    oldCart.Quantity += cart.Quantity;
                }
                //amount of product is max
                if (product.Amount < oldCart.Quantity)
                {
                    oldCart.Quantity = product.Amount;
                    isQuantityFull = true;
                }

                oldCart.UpdateAt = DateTime.Now;
                _db.Cart.Update(oldCart);

            }

            try
            {
                await _db.SaveAsync();
                //check quantity full in product, if user add more than quanity 
                if (isQuantityFull) return BadRequest(new ErrorApp { Error = ErrorContent.CheckQuantity });
                
                return NoContent();
            }
            catch
            {
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }

        // GET: api/Carts/GetCartsUser
        [HttpGet("GetCartsUser")]
        public async Task<ActionResult<List<Cart>>> GetCartsUser()
        {
            User user = new();
            //get user info
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // get user by userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            //get list cart of user by user id
            var carts = await _db.Cart.GetAllAsync(x => x.UserId == user.Id,
                includeProperties: "Product");

            return carts.ToList();
        }

        // GET: api/Carts/CheckQuantity
        [HttpGet("CheckQuantity")]
        public async Task<ActionResult> CheckQuantity()
        {
            User user = new();
            //get user info
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // get user by user Id
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            //get cart of user
            var carts = await _db.Cart.GetAllAsync(x => x.UserId == user.Id,
                includeProperties: "Product");

            //compare quantity in cart with amount of product
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
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }
    }
}
