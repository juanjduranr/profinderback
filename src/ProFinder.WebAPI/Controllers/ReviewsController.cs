using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.WebAPI.DTO;
using ProFinder.WebAPI.Mappers;
using System;
using System.Collections.Generic;

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
                //Log Exception
                return StatusCode(500);
            }
        }

        [Route("{reviewId:int}")]
        public IActionResult Get(int companyId, int reviewId)
        {
            try
            {
                var review = _reviewRepository.GetByCompany(reviewId, companyId);
                var dto = new ReviewDto();
                ReviewToDtoMapper.Map(review, dto);
                return Ok(dto);
            }
            catch (Exception)
            {
                //Log exception
                return StatusCode(500);
            }
        }
    }
}