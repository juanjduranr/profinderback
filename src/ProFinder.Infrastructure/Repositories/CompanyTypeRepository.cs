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

        public void Add(CompanyType companyType)
        {
            _db.CompanyTypes.Add(companyType);
        }

        public void Delete(CompanyType companyType)
        {
            _db.CompanyTypes.Remove(companyType);
        }

        public IEnumerable<CompanyType> GetAll()
        {
            return _db.CompanyTypes.ToList();
        }

        public CompanyType GetById(int id)
        {
            return _db.CompanyTypes.FirstOrDefault(c => c.Id == id);
        }

        public void Update(CompanyType companyType)
        {
            _db.CompanyTypes.Update(companyType);
        }
    }
}
