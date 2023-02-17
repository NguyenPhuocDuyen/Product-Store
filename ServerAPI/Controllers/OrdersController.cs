using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
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

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _db.Order.GetAllAsync(includeProperties: "Status,User"));
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _db.Order.GetFirstOrDefaultAsync(filter: x => x.Id == id,includeProperties: "Status,User");

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            try
            {
                _db.Order.Update(order);
                await _db.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _db.Order.Add(order);
            await _db.SaveAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _db.Order.GetFirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            _db.Order.Remove(order);
            await _db.SaveAsync();

            return NoContent();
        }

        private async Task<bool> OrderExists(int id)
        {
            var order = await _db.Order.GetFirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                return false;
            }
            return true;
        }
    }
}
