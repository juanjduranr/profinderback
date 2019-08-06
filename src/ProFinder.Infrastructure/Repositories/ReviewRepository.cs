using ProFinder.Core.Entities;
using ProFinder.Core.Interfaces.Repositories;
using ProFinder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProFinder.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProFinderContext _db;

        public ReviewRepository(ProFinderContext db)
        {
            _db = db;
        }

        public IEnumerable<Review> GetAllByCompany(int companyId)
        {
            return _db.Reviews.Where(r => r.CompanyId == companyId).Include(r => r.Customer);
        }

        public Review GetByCompany(int reviewId, int companyId)
        {
            return _db.Reviews.FirstOrDefault(r => r.Id == reviewId && r.CompanyId == companyId);
        }
    }
}
