using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces.Repositories;
using System;

namespace ProFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypesController : ControllerBase
    {
        private readonly ICompanyTypeRepository _companyTypeRepository;

        public CompanyTypesController(ICompanyTypeRepository companyTypeRepository)
        {
            _companyTypeRepository = companyTypeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var companyTypes = _companyTypeRepository.GetAll();
                return Ok(companyTypes);
            }
            catch (Exception)
            {
                //Log Exception
                return StatusCode(500);
            }
        }

    }
}