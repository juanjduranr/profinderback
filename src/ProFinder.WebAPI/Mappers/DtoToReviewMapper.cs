using ProFinder.Core.Entities;
using ProFinder.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Mappers
{
    public static class DtoToReviewMapper
    {

        public static void Map(ReviewDto fromValue, Review toValue)
        {
            if (fromValue == null)
                throw new ArgumentException("Argument cannot be null", "fromValue");

            if (toValue == null)
                throw new ArgumentException("Argument cannot be null", "toValue");

            toValue.Comment = fromValue.Comment;
            toValue.Rating = fromValue.Rating;
            toValue.CustomerId = fromValue.CustomerId;
            toValue.CompanyId = fromValue.CompanyId;
            toValue.Date = fromValue.Date;
        }

        
    }
}
