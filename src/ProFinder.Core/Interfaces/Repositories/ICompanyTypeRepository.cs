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
    }
}
