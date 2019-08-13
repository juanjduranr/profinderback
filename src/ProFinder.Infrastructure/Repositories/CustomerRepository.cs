using ProFinder.Core.Entities;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProFinder.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProFinderContext _db;

        public CustomerRepository(ProFinderContext db)
        {
            _db = db;
        }

        public Customer GetByExternalId(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.ExternalId == id);
        }

        public void Update(Customer customer)
        {
            _db.Customers.Update(customer);
        }
    }
}
