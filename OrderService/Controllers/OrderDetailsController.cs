using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public OrderDetailsController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/OrderDetails/5
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderDetail(int orderId)
        {
            var orderDetails = await _db.OrderDetail.GetAllAsync(filter: x=>x.OrderId == orderId, includeProperties: "Order,Product");
            var user = await _db.User.GetAllAsync();
            orderDetails = orderDetails.Join(user, 
                orderdetail => orderdetail.Order.UserId, 
                user => user.Id, 
                (orderdetail, user) => orderdetail);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }
    }
}
