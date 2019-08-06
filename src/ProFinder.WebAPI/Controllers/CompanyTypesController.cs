using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces.Repositories;

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
                return StatusCode(500);
            }
        }

    }
}