using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.WebAPI.DTO;
using ProFinder.WebAPI.Extensions;
using ProFinder.WebAPI.Mappers;
using Serilog;
using System;

namespace ProFinder.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfilesController(ICustomerRepository customerRepository,
                                  IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customerExtarnalId = User.GetExternalId();
                var customer = _customerRepository.GetByExternalId(customerExtarnalId);
                if (customer == null)
                    return NotFound();

                var dto = new CustomerDto();
                CustomerToDtoMapper.Map(customer, dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"unhandled exception");
                return StatusCode(500, ex);
            }            
        }

        [HttpPut("{externalId}")]
        public IActionResult Put(int externalId, CustomerDto dto)
        {
            try
            {
                var customerExtarnalId = User.GetExternalId();
                if (externalId != customerExtarnalId)
                    return BadRequest();

                if (dto.ExternalId != customerExtarnalId)
                    return BadRequest();

                var customer = _customerRepository.GetByExternalId(customerExtarnalId);
                if (customer == null)
                    return NotFound();

                customer.FirstName = dto.Name;
                customer.LastName = dto.LastName;
                customer.Email = dto.Email;
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"unhandled exception");
                return StatusCode(500, ex);
            }
        }
    }
}