using Microsoft.EntityFrameworkCore;
using ProFinder.Core.Entities;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProFinder.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ProFinderContext _db;

        public CompanyRepository(ProFinderContext db)
        {
            _db = db;
        }

        public void Add(Company company)
        {
            _db.Companies.Add(company);
        }

        public void Delete(Company company)
        {
            _db.Companies.Remove(company);
        }

        public IEnumerable<Company> GetAll()
        {
            return _db.Companies.Include(c => c.Reviews).ThenInclude(r => r.Customer)
                                .Include(c => c.CompanyType)
                                .ToList();
        }

        public Company GetById(int id)
        {
            return _db.Companies.Include(c => c.Reviews).ThenInclude(r => r.Customer)
                                .Include(c => c.CompanyType)
                                .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Company company)
        {
            _db.Companies.Update(company);
        }
    }
}
