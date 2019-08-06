using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Interfaces.Repositories
{
    public interface ICompanyTypeRepository
    {
        IEnumerable<CompanyType> GetAll();
        CompanyType GetById(int id);
        void Add(CompanyType companyType);
        void Update(CompanyType companyType);
        void Delete(CompanyType companyType);
    }
}
