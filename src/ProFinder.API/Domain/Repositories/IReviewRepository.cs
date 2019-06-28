using ProFinder.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Domain.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();
        IEnumerable<Review> GetAllByCompany(int companyId);
        Review GetById(int id);
        Review GetByCompanyById(int reviewId, int companyId);
    }
}
