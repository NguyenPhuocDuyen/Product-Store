using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class OrderDetailsController : ControllerBase
    //{
    //    private readonly IUnitOfWork _db;

    //    public OrderDetailsController(IUnitOfWork db)
    //    {
    //        _db = db;
    //    }

    //    //// GET: api/OrderDetails
    //    //[HttpGet]
    //    //public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
    //    //{
    //    //    return Ok(await _db.OrderDetail.GetAllAsync());
    //    //}

    //    //// GET: api/OrderDetails/5
    //    //[HttpGet("{id}")]
    //    //public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
    //    //{
    //    //    var orderDetail = await _db.OrderDetail.GetFirstOrDefaultAsync(filter: x => x.Id == id, includeProperties: "Order,Product");

    //    //    if (orderDetail == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    return orderDetail;
    //    //}

    //    //// PUT: api/OrderDetails/5
    //    //[HttpPut("{id}")]
    //    //public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
    //    //{
    //    //    if (id != orderDetail.Id)
    //    //    {
    //    //        return BadRequest();
    //    //    }

    //    //    try
    //    //    {
    //    //        _db.OrderDetail.Update(orderDetail);
    //    //        await _db.SaveAsync();
    //    //    }
    //    //    catch (DbUpdateConcurrencyException)
    //    //    {
    //    //        if (!await OrderDetailExists(id))
    //    //        {
    //    //            return NotFound();
    //    //        }
    //    //        else
    //    //        {
    //    //            throw;
    //    //        }
    //    //    }

    //    //    return NoContent();
    //    //}

    //    //// POST: api/OrderDetails
    //    //[HttpPost]
    //    //public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
    //    //{
    //    //    _db.OrderDetail.Add(orderDetail);
    //    //    await _db.SaveAsync();

    //    //    return CreatedAtAction("GetOrderDetail", new { id = orderDetail.Id }, orderDetail);
    //    //}

    //    //// DELETE: api/OrderDetails/5
    //    //[HttpDelete("{id}")]
    //    //public async Task<IActionResult> DeleteOrderDetail(int id)
    //    //{
    //    //    var orderDetail = await _db.OrderDetail.GetFirstOrDefaultAsync(x => x.Id == id);
    //    //    if (orderDetail == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    _db.OrderDetail.Remove(orderDetail);
    //    //    await _db.SaveAsync();

    //    //    return NoContent();
    //    //}

    //    //private async Task<bool> OrderDetailExists(int id)
    //    //{
    //    //    var orderDetail = await _db.OrderDetail.GetFirstOrDefaultAsync(x => x.Id == id);
    //    //    if (orderDetail == null)
    //    //    {
    //    //        return false;
    //    //    }
    //    //    return true;
    //    //}
    //}
}
