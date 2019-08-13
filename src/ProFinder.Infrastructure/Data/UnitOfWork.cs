using ProFinder.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProFinderContext _db;

        public UnitOfWork(ProFinderContext db)
        {
            _db = db;
        }

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}
