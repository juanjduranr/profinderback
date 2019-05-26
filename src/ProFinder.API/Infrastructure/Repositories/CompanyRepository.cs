using ProFinder.API.Domain.Entities;
using ProFinder.API.Domain.Repositories;
using ProFinder.API.Infrastructure.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ProFinderDbContext _context;

        public CompanyRepository(ProFinderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies
                           .Include(c => c.ServiceType)
                           .Select(c => new Company
                           {
                               Id = c.Id,
                               Description = c.Description,
                               Name = c.Name,
                               StartDate = c.StartDate,
                               ServiceType = new ServiceType
                               {
                                   Id = c.ServiceType.Id,
                                   Name = c.ServiceType.Name
                               }                               
                           })
                           .ToList();
        }

        public Company GetById(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == id);
        }
    }
}
