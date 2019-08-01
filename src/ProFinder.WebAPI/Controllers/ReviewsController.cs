using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces.Repositories;

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
                var companies = _reviewRepository.GetAllByCompany(companyId);
                return Ok(companies);
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
                var companies = _reviewRepository.GetByCompany(reviewId, companyId);
                return Ok(companies);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}