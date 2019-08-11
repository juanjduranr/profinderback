using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.WebAPI.DTO;
using ProFinder.WebAPI.Mappers;
using System;
using System.Collections.Generic;

namespace ProFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult Get(bool includeReviews = false)
        {
            try
            {
                var companies = _companyRepository.GetAll();
                var dtos = new List<CompanyDto>();
                CompanyToDtoMapper.Map(companies, dtos, includeReviews);
                return Ok(dtos);
            }
            catch (Exception e)
            {
                //Log Exception
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, bool includeReviews = true)
        {
            try
            {
                var company = _companyRepository.GetById(id);
                if (company == null)
                    return NotFound();

                var dto = new CompanyDto();
                CompanyToDtoMapper.Map(company, dto, includeReviews);
                return Ok(dto);
            }
            catch (Exception e)
            {
                //Log Exception
                return StatusCode(500, e);
            }
        }
    }
}