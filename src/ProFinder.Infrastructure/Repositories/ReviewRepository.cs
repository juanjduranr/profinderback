using ProFinder.Core.Entities;
using ProFinder.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public IEnumerable<Review> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetAllByCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public Review GetByCompanyById(int reviewId, int companyId)
        {
            throw new NotImplementedException();
        }

        public Review GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
