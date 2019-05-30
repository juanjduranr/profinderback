using Microsoft.AspNetCore.Mvc;
using ProFinder.API.Domain.Repositories;
using System;

namespace ProFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypesController : ControllerBase
    {
        private readonly ICompanyTypeRepository _repository;

        public CompanyTypesController(ICompanyTypeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}