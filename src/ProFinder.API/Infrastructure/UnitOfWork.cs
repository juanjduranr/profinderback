using ProFinder.API.Domain;
using ProFinder.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProFinderDbContext _context;

        public UnitOfWork(ProFinderDbContext context)
        {
            _context = context;            
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
