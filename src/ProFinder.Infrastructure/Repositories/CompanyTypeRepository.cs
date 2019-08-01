using System;
using System.Collections.Generic;
using System.Text;
using ProFinder.Core.Entities;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.Infrastructure.Data;
using System.Linq;

namespace ProFinder.Infrastructure.Repositories
{
    public class CompanyTypeRepository : ICompanyTypeRepository
    {
        private readonly ProFinderContext _db;

        public CompanyTypeRepository(ProFinderContext db)
        {
            _db = db;
        }

        public IEnumerable<CompanyType> GetAll()
        {
            return _db.CompanyTypes.ToList();
        }

        public CompanyType GetById(int id)
        {
            return _db.CompanyTypes.FirstOrDefault(c => c.Id == id);
        }
    }
}
