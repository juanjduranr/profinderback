using ProFinder.API.Domain.Entities;
using ProFinder.API.Domain.Repositories;
using ProFinder.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Infrastructure.Repositories
{
    public class CompanyTypeRepository : ICompanyTypeRepository
    {
        private readonly ProFinderDbContext _context;

        public CompanyTypeRepository(ProFinderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ServiceType> GetAll()
        {
            return _context.ServiceTypes.ToList();
        }

        public ServiceType GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
