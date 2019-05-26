using ProFinder.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Domain.Repositories
{
    public interface ICompanyRepository
    {        
        IEnumerable<Company> GetAll();
        Company GetById(int id);
    }
}
