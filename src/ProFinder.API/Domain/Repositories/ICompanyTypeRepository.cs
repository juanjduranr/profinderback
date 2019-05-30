using ProFinder.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Domain.Repositories
{
    public interface ICompanyTypeRepository
    {
        IEnumerable<ServiceType> GetAll();
        ServiceType GetById(int id);
    }
}
