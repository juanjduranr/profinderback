using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.WebAPI.DTO;
using ProFinder.WebAPI.Extensions;
using ProFinder.WebAPI.Mappers;
using System;
using System.Collections.Generic;

namespace ProFinder.WebAPI.Controllers
{    
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IReviewRepository reviewRepository,
                                 IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/companies/{companyId}/reviews")]
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
                
        [Route("api/companies/{companyId}/reviews/{reviewId:int}")]
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

        [Route("api/reviews")]
        public IActionResult Post(AddReviewDto dto)
        {
            try
            {
                var model = new Core.Entities.Review()
                {
                    Rating = dto.Rating,
                    Comment = dto.Comment,
                    CompanyId = dto.CompanyId,
                    CustomerId = dto.CustomerId,
                    Date = DateTime.Now
                };
                _reviewRepository.Add(model);
                _unitOfWork.Save();
                return Created("", dto);
            }
            catch (Exception)
            {
                //Log exception
                return StatusCode(500);
            }
        }

        [Route("api/reviews/{id}")]
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var review = _reviewRepository.Get(id);
                if (review == null)
                    return BadRequest();

                var userExternalId = User.GetExternalId();
                if (userExternalId != review.Customer.ExternalId)
                    return Forbid();

                _reviewRepository.Delete(review);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                //Log exception
                return StatusCode(500, e);
            }
        }
    }
}