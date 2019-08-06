using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.WebAPI.DTO;
using ProFinder.WebAPI.Mappers;

namespace ProFinder.WebAPI.Controllers
{
    [Route("api/companies/{companyId}/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public IActionResult Get(int companyId)
        {
            try
            {
                var reviews = _reviewRepository.GetAllByCompany(companyId);                                
                var dtos = new List<ReviewDto>();
                ReviewToDtoMapper.Map(reviews, dtos);
                return Ok(dtos);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Route("{reviewId:int}")]
        public IActionResult Get(int companyId, int reviewId)
        {
            try
            {
                var review = _reviewRepository.GetByCompany(reviewId, companyId);
                return Ok(review);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}