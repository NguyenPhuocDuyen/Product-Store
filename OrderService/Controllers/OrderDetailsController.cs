using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public OrderDetailsController(IUnitOfWork db)
        {
            _db = db;
        }

        // when order has status is OrderReceived
        // GET: api/OrderDetails/GetOrderDetailReceived
        [HttpGet("GetOrderDetailReceived")]
        public async Task<ActionResult<List<OrderDetail>>> GetOrderDetailReceived()
        {
            var orderDetails = await _db.OrderDetail.GetAllAsync(filter: x => x.Order.StatusId == 3, includeProperties: "Order");

            if (orderDetails == null)
                return NotFound(new ErrorApp { Error = ErrorContent.NotFound });

            return orderDetails.ToList();
        }

        // GET: api/OrderDetails/5
        [Authorize]
        [HttpGet("{orderId}")]
        public async Task<ActionResult<List<OrderDetail>>> GetOrderDetail(int orderId)
        {
            //get list order detail by order id
            var orderDetails = await _db.OrderDetail.GetAllAsync(filter: x => x.OrderId == orderId, includeProperties: "Order,Product");

            if (orderDetails == null)
                return NotFound(new ErrorApp { Error = ErrorContent.NotFound });

            //get list user
            var user = await _db.User.GetAllAsync();
            //join user into orderdetail
            orderDetails = orderDetails.Join(user,
                orderdetail => orderdetail.Order.UserId,
                user => user.Id,
                (orderdetail, user) => orderdetail);

            return orderDetails.ToList();
        }
    }
}
