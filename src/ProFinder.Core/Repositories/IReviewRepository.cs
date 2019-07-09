using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();
        IEnumerable<Review> GetAllByCompany(int companyId);
        Review GetById(int id);
        Review GetByCompanyById(int reviewId, int companyId);
    }
}
