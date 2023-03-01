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
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public OrdersController(IUnitOfWork db)
        {
            _db = db;
        }

        //// GET: api/Orders
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        //{
        //    return Ok(await _db.Order.GetAllAsync());
        //}

        //// GET: api/Orders/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Order>> GetOrder(int id)
        //{
        //    var order = await _db.Order.GetFirstOrDefaultAsync(filter: x => x.Id == id,includeProperties: "Status,User");

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return order;
        //}

        //// PUT: api/Orders/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(int id, Order order)
        //{
        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        _db.Order.Update(order);
        //        await _db.SaveAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!await OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Orders
        //[HttpPost]
        //public async Task<ActionResult<Order>> PostOrder(Order order)
        //{
        //    _db.Order.Add(order);
        //    await _db.SaveAsync();

        //    return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        //}

        //// DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder(int id)
        //{
        //    var order = await _db.Order.GetFirstOrDefaultAsync(x => x.Id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Order.Remove(order);
        //    await _db.SaveAsync();

        //    return NoContent();
        //}

        //private async Task<bool> OrderExists(int id)
        //{
        //    var order = await _db.Order.GetFirstOrDefaultAsync(x => x.Id == id);
        //    if (order == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        [Authorize]
        [HttpGet("OrderProducts")]
        public async Task<IActionResult> OrderProducts()
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            var carts = await _db.Cart.GetAllAsync(
                x => x.UserId == user.Id,
                includeProperties: "Product");

            if (carts.Count() > 0 && !string.IsNullOrEmpty(user.Address))
            {
                Order order = new()
                {
                    UserId = user.Id,
                    OrderAddress = user.Address,
                    StatusId = 4
                };
                _db.Order.Add(order);
                await _db.SaveAsync();

                var orderList = await _db.Order.GetAllAsync();
                var orderNew = orderList.OrderByDescending(x => x.Id).FirstOrDefault();

                foreach (var item in carts)
                {
                    var pro =await _db.Product.GetFirstOrDefaultAsync(x=>x.Id == item.ProductId);
                    pro.Amount -= item.Quantity;
                    _db.Product.Update(pro);

                    _db.OrderDetail.Add(new OrderDetail
                    {
                        ProductId = item.ProductId,
                        OrderId = orderNew.Id,
                        Amount = item.Quantity,
                        PaymentPrice = item.Product.RecentPrice
                    });
                    _db.Cart.Remove(item);
                }
                await _db.SaveAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}
