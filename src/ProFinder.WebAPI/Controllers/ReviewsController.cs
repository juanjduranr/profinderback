﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.WebAPI.DTO;
using ProFinder.WebAPI.Extensions;
using ProFinder.WebAPI.Mappers;
using Serilog;
using System;
using System.Collections.Generic;

namespace ProFinder.WebAPI.Controllers
{    
    [ApiController]
    [Route("api/companies/{companyId}/reviews")]
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
        public IActionResult Get(int companyId)
        {
            try
            {
                var reviews = _reviewRepository.GetAllByCompany(companyId);                                
                var dtos = new List<ReviewDto>();
                ReviewToDtoMapper.Map(reviews, dtos);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"unhandled exception");
                return StatusCode(500, ex);
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
            catch (Exception ex)
            {
                Log.Error(ex, $"unhandled exception");
                return StatusCode(500, ex);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(int companyId, [FromBody]ReviewDto dto)
        {
            try
            {
                var customerExtarnalId = User.GetExternalId();
                if (customerExtarnalId != dto.CustomerId)
                    return Forbid();

                var customer = _customerRepository.GetByExternalId(customerExtarnalId);
                if (customer == null)
                    return Forbid();

                if (dto.Rating < 1  || dto.Rating > 5)
                    return BadRequest("rating cannot be less than 1 and greater than 5");
                
                dto.Date = DateTime.Now;
                var model = new Core.Entities.Review();
                DtoToReviewMapper.Map(dto, model);
                _reviewRepository.Add(model);
                _unitOfWork.Save();
                dto.Id = model.Id;
                return Created($"api/companies/{companyId}/reviews/{model.Id}", dto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"unhandled exception");
                return StatusCode(500, ex);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{reviewId:int}")]
        public IActionResult Delete(int companyId, int reviewId)
        {
            try
            {
                var review = _reviewRepository.Get(reviewId);
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
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"unhandled exception");
                return StatusCode(500, ex);
            }
        }
    }
}