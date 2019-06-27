using ProFinder.API.Domain.Entities;
using ProFinder.API.Domain.Repositories;
using ProFinder.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProFinderDbContext _context;

        public ReviewRepository(ProFinderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public IEnumerable<Review> GetAllByCompany(int companyId)
        {
            return _context.Reviews.Where(r => r.Company.Id == companyId).ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }
    }
}
