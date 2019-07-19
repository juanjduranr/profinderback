using ProFinder.Core.Entities;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
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

        public IEnumerable<Company> GetAll()
        {
            return _db.Companies.ToList();
        }

        public Company GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
