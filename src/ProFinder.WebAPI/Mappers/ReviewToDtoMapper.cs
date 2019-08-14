using ProFinder.Core.Entities;
using ProFinder.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Mappers
{
    public class ReviewToDtoMapper
    {
        public static void Map(Review fromValue, ReviewDto toValue)
        {
            if (fromValue == null)
                throw new ArgumentException("Argument cannot be null", "fromValue");

            if (toValue == null)
                throw new ArgumentException("Argument cannot be null", "toValue");

            toValue.Id = fromValue.Id;
            toValue.Comment = fromValue.Comment;
            toValue.CustomerName = $"{fromValue.Customer.FirstName} {fromValue.Customer.LastName.First()}.";
            toValue.Date = fromValue.Date;
            toValue.Rating = fromValue.Rating;
            toValue.CustomerId = fromValue.Customer.Id;
            toValue.CompanyId = fromValue.CompanyId;
        }

        public static void Map(IEnumerable<Review> fromValues, IList<ReviewDto> toValues)
        {
            if (fromValues == null)
                throw new ArgumentNullException("fromValues is null.", "fromValues");

            ReviewDto toValue;

            foreach (var fromValue in fromValues)
            {
                toValue = new ReviewDto();

                Map(fromValue, toValue);

                toValues.Add(toValue);
            }
        }
    }
}
