using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public OrdersController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Orders
        [Authorize(Roles = "Admin")]
        [HttpGet("GetOrders")]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var listOrder = await _db.Order.GetAllAsync(includeProperties: "Status,User");
            listOrder = listOrder.OrderByDescending(x => x.CreateAt)
                .ThenBy(x => x.StatusId).ToList();

            return listOrder.ToList();
        }

        // GET: api/Orders/5
        [HttpGet("GetOrdersOfUser")]
        public async Task<ActionResult<List<Order>>> GetOrdersOfUser()
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            var orders = await _db.Order.GetAllAsync(
                filter: x => x.UserId == user.Id, 
                includeProperties: "Status,User,OrderDetails");

            if (orders == null)
            {
                return NotFound();
            }
            
            orders = orders.OrderByDescending(x=>x.CreateAt).ThenBy(x=>x.StatusId).ToList();
            var products = _db.Product;

            return orders.ToList();
        }

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

        //private async Task<bool> OrderExists(int id)
        //{
        //    var order = await _db.Order.GetFirstOrDefaultAsync(x => x.Id == id);
        //    if (order == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

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

            if (carts.Any() && !string.IsNullOrEmpty(user.Address))
            {
                Order order = new()
                {
                    UserId = user.Id,
                    OrderAddress = user.Address,
                    StatusId = 1
                };
                _db.Order.Add(order);
                await _db.SaveAsync();

                var orderList = await _db.Order.GetAllAsync();
                var orderNew = orderList.OrderByDescending(x => x.Id).FirstOrDefault();

                foreach (var item in carts)
                {
                    var pro = await _db.Product.GetFirstOrDefaultAsync(x => x.Id == item.ProductId);
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

        [HttpPost("ConfirmOrder/{id}")]
        public async Task<IActionResult> ConfirmOrder(int id, int statusId)
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            var order = await _db.Order.GetFirstOrDefaultAsync(x=>x.Id == id);
            if (user.RoleId != 1)
            {
                if (order.UserId != user.Id)
                {
                    return NotFound();
                }
                statusId = 4;
            }
            
            order.StatusId = statusId;
            try
            {
                _db.Order.Update(order);
                await _db.SaveAsync();
                return Ok();
            }
            catch { }
            return BadRequest();
        }
    }
}
