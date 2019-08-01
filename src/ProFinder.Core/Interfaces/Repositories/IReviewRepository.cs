using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Interfaces.Repositories
{
    public interface IReviewRepository
    {        
        IEnumerable<Review> GetAllByCompany(int companyId);        
        Review GetByCompany(int reviewId, int companyId);
    }
}
