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
    public class ReviewsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public ReviewsController(IUnitOfWork db)
        {
            _db = db;
        }

        //// GET: api/Reviews
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        //{
        //    return Ok(await _db.Review.GetAllAsync());
        //}

        //// GET: api/Reviews/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Review>> GetReview(int id)
        //{
        //    var review = await _db.Review.GetFirstOrDefaultAsync(filter: x => x.Id == id, includeProperties: "Product,User");

        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    return review;
        //}

        //// PUT: api/Reviews/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReview(int id, Review review)
        //{
        //    if (id != review.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        _db.Review.Update(review);
        //        await _db.SaveAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!await ReviewExists(id))
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

        //// POST: api/Reviews
        //[HttpPost]
        //public async Task<ActionResult<Review>> PostReview(Review review)
        //{
        //    _db.Review.Add(review);
        //    await _db.SaveAsync();

        //    return CreatedAtAction("GetReview", new { id = review.Id }, review);
        //}

        //// DELETE: api/Reviews/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteReview(int id)
        //{
        //    var review = await _db.Review.GetFirstOrDefaultAsync(x => x.Id == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Review.Remove(review);
        //    await _db.SaveAsync();

        //    return NoContent();
        //}

        //private async Task<bool> ReviewExists(int id)
        //{
        //    var review = await _db.Review.GetFirstOrDefaultAsync(x => x.Id == id);
        //    if (review == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
