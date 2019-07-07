using Microsoft.AspNetCore.Mvc;
using ProFinder.API.Domain.Repositories;
using ProFinder.API.Dto;
using System;
using System.Linq;

namespace ProFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _repository;

        public CompaniesController(ICompanyRepository repository)
        {
            _repository = repository;            
        }

        public IActionResult Get()
        {
            try
            {
                var companies = _repository.GetAll();
                
                var dtos = companies.Select(c =>
                new CompanyDto
                {
                    Id = c.Id,
                    Description = c.Description,
                    Name = c.Name,
                    ServiceTypeId = c.ServiceType.Id,
                    ServiceTypeName = c.ServiceType.Name,
                    StartDate = c.StartDate,
                    ReviewsCount = c.Reviews.Count,
                    Rating = c.Reviews.Sum(r => r.Rating) / (c.Reviews.Count == 0 ? 1 : c.Reviews.Count)
                });

                return Ok(dtos);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var company = _repository.GetById(id);

                var dto = new CompanyDto
                {
                    Id = company.Id,
                    Description = company.Description,
                    Name = company.Name,
                    ServiceTypeId = company.ServiceType.Id,
                    ServiceTypeName = company.ServiceType.Name,
                    StartDate = company.StartDate,
                    ReviewsCount = company.Reviews.Count,
                    Rating = company.Reviews.Sum(r => r.Rating) / (company.Reviews.Count == 0 ? 1 : company.Reviews.Count)
                };

                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}