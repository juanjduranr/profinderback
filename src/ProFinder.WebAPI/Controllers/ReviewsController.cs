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
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IReviewRepository reviewRepository,
                                 ICustomerRepository customerRepository,
                                 IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _customerRepository = customerRepository;
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

        [Authorize]
        [Route("api/reviews")]
        public IActionResult Post(ReviewDto dto)
        {
            try
            {
                var customerExtarnalId = User.GetExternalId();
                if (customerExtarnalId != dto.CustomerId)
                    return Forbid();

                var customer = _customerRepository.GetByExternalId(customerExtarnalId);
                if (customer == null)
                    return Forbid();
                
                dto.Date = DateTime.Now;
                var model = new Core.Entities.Review();
                DtoToReviewMapper.Map(dto, model);
                _reviewRepository.Add(model);
                _unitOfWork.Save();
                dto.Id = model.Id;
                return Created("", dto);
            }
            catch (Exception)
            {
                //Log exception
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("api/reviews/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var review = _reviewRepository.Get(id);
                if (review == null)
                    return BadRequest();

                var customerExtarnalId = User.GetExternalId();
                var customer = _customerRepository.GetByExternalId(customerExtarnalId);
                if (customer == null)
                    return Forbid();

                if (customerExtarnalId != review.Customer.ExternalId)
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