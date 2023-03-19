using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
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

        //get all review
        // GET: api/Reviews/GetReviewsOfProduct
        [HttpGet("GetReviewsOfProduct")]
        public async Task<ActionResult<List<Review>>> GetReviewsOfProduct()
        {
            return (await _db.Review.GetAllAsync()).ToList();
        }

        //get review of one product
        // GET: api/Reviews/GetReviewsOfProduct/1
        [HttpGet("GetReviewsOfProduct/{id}")]
        public async Task<ActionResult<List<Review>>> GetReviewsOfProduct(int id)
        {
            return (await _db.Review.GetAllAsync(filter: x => x.ProductId == id, includeProperties: "User")).ToList();
        }

        // POST: api/Reviews/AddReview
        [HttpPost("AddReview")]
        public async Task<ActionResult> PostReview(Review review)
        {
            User user = new();
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                // get user by id
                user = await _db.User.GetFirstOrDefaultAsync(x => x.Id == int.Parse(userId));
            }

            //get old review of user for one product
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
                return BadRequest(new ErrorApp { Error = ErrorContent.Error });
            }
        }
    }
}
