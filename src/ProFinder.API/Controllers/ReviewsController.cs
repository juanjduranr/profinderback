using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProFinder.API.Domain.Entities;
using ProFinder.API.Domain.Repositories;

namespace ProFinder.API.Controllers
{
    [Route("api/companies/{id}/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        
        public IActionResult Get(int id)
        {
            try
            {
                var reviews = _reviewRepository.GetAllByCompany(id);
                return Ok(reviews);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Route("{reviewId:int}")]
        public IActionResult Get(int id, int reviewId)
        {
            try
            {
                var review = _reviewRepository.GetByCompanyById(reviewId, id);
                if (review == null)
                    return NotFound();

                return Ok(review);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}