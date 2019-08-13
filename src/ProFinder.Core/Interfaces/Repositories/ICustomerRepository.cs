using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetByExternalId(int id);
        void Update(Customer customer);
    }
}
