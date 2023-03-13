using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReviewService.Controllers
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

        // GET: api/Reviews
        [HttpGet("GetReviewsOfProduct/{id}")]
        public async Task<ActionResult<List<Review>>> GetReviewsOfProduct(int id)
        {
            return (await _db.Review.GetAllAsync(filter: x => x.ProductId == id, includeProperties: "User")).ToList();
        }

        // POST: api/Reviews
        [HttpPost("AddReview")]
        public async Task<IActionResult> PostReview(Review review)
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // Lấy thông tin người dùng dựa vào userId
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            var oldReview = await _db.Review.GetFirstOrDefaultAsync(x => x.UserId == user.Id && x.ProductId == review.ProductId);
            //check exist review to add or update
            if (oldReview == null)
            {
                review.UserId = user.Id;
                _db.Review.Add(review);
            }
            else
            {
                oldReview.Description = review.Description;
                oldReview.Rate = review.Rate;
                oldReview.UpdateAt = DateTime.Now;
                _db.Review.Update(oldReview);
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
    }
}
