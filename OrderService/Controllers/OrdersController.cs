using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Models;
using Models.ViewModel;
using System;
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

        // GET: api/Orders/5 get order list of user authentica
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
            bool isAdmin = false;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                var role = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                // Lấy thông tin người dùng dựa vào userId
                isAdmin = role == RoleContent.Admin;
            }

            IEnumerable<Order> listOrder = new List<Order>();

            if (isAdmin)
            {
                listOrder = await _db.Order.GetAllAsync(includeProperties: "Status,User");
            }
            else
            {
                listOrder = await _db.Order.GetAllAsync(
                    filter: x => x.UserId == user.Id,
                    includeProperties: "Status,User");
            }

            listOrder = listOrder.OrderBy(x => x.StatusId).ThenByDescending(x => x.CreateAt).ToList();
            var products = _db.Product;

            return listOrder.ToList();
        }

        //order product in cart
        [HttpGet("OrderProducts")]
        public async Task<IActionResult> OrderProducts()
        {
            //get info user
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            bool isAdmin = false;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                var role = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                // Lấy thông tin người dùng dựa vào userId
                isAdmin = role == RoleContent.Admin;
            }

            if (isAdmin) return NotFound();

            //get cart of user
            var carts = await _db.Cart.GetAllAsync(
                x => x.UserId == user.Id,
                includeProperties: "Product");

            //check null
            if (carts.Any() && !string.IsNullOrEmpty(user.Address))
            {
                var listProduct = await _db.Product.GetAllAsync();
                bool isCheckQuantitySuccess = true; // check Amount of product must be geater than quantity in cart
                foreach (var item in carts)
                {
                    var pro = listProduct.Where(x => x.Id == item.ProductId).FirstOrDefault();
                    if (pro.Amount < item.Quantity)
                    {
                        isCheckQuantitySuccess = false;
                        item.Quantity = pro.Amount;
                        if (pro.Amount == 0) // out of amount product
                        {
                            _db.Cart.Remove(item); // remove product in cart when amount product equal 0
                        }
                        else
                        {
                            _db.Cart.Update(item);
                        }
                    }
                }
                await _db.SaveAsync();

                if (isCheckQuantitySuccess)
                {
                    //create order
                    Order order = new()
                    {
                        UserId = user.Id,
                        OrderAddress = user.Address,
                        StatusId = 1
                    };
                    _db.Order.Add(order);
                    await _db.SaveAsync();

                    //get order new
                    var orderList = await _db.Order.GetAllAsync();
                    var orderNew = orderList.OrderByDescending(x => x.Id).FirstOrDefault();

                    //add product from cart to orderdeatil for order
                    foreach (var item in carts)
                    {
                        //sub quantity of product
                        var pro = listProduct.Where(x => x.Id == item.ProductId).FirstOrDefault();
                        pro.Amount -= item.Quantity;
                        _db.Product.Update(pro);

                        //delete all product by id when amount sold out
                        if (pro.Amount == 0)
                        {
                            var listProductOfOne = await _db.Cart.GetAllAsync(filter: x => x.ProductId == pro.Id);
                            foreach (var proInCart in listProductOfOne)
                            {
                                //remove another obj in cart
                                if (item.Id != proInCart.Id)
                                    _db.Cart.Remove(proInCart);
                            }
                        }

                        //add orderDeatial and remove product in cart
                        OrderDetail orderDetail = new()
                        {
                            ProductId = item.ProductId,
                            OrderId = orderNew.Id,
                            Amount = item.Quantity,
                            PaymentPrice = item.Product.RecentPrice
                        };
                        _db.OrderDetail.Add(orderDetail);
                        _db.Cart.Remove(item);
                    }
                    await _db.SaveAsync();

                    return NoContent();
                }
            }

            return NotFound();
        }


        //admin confirm order for user
        [HttpPost("ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder(Order o)
        {
            var order = await _db.Order.GetFirstOrDefaultAsync(x => x.Id == o.Id);

            if (order == null)
                return NotFound();

            //get info user
            bool isAdmin = false;
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                string role = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                // Sử dụng role ở đây để thực hiện kiểm tra quyền truy cập và thực hiện các hoạt động khác liên quan đến role.
                isAdmin = role == RoleContent.Admin;
            }

            // only admin can be accept order
            if (!isAdmin)
            {
                if (o.StatusId == 2)
                {
                    return BadRequest();
                }
            }

            //can not reject order when it not yet accept
            if (order.StatusId == 1 && o.StatusId == 3)
            {
                return BadRequest();
            }

            //cancel order so amount of product must to increate
            if (o.StatusId == 4)
            {
                var listOrder = await _db.OrderDetail.GetAllAsync(filter: x => x.OrderId == o.Id);
                foreach (var item in listOrder)
                {
                    var product = await _db.Product.GetFirstOrDefaultAsync(filter: x => x.Id == item.ProductId);
                    product.Amount += item.Amount;
                    _db.Product.Update(product);
                }
            }

            order.StatusId = o.StatusId;
            order.UpdateAt = DateTime.Now;
            _db.Order.Update(order);
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
    }
}
