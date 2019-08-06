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
                throw new ArgumentException("fromValue", "Argument cannot be null");

            if (toValue == null)
                throw new ArgumentException("toValue", "Argument cannot be null");

            toValue.Id = fromValue.Id;
            toValue.Comment = fromValue.Comment;
            toValue.CustomerName = $"{fromValue.Customer.FirstName} {fromValue.Customer.LastName.First()}.";
            toValue.Date = fromValue.Date;
            toValue.Rating = fromValue.Rating;                     
        }

        public static void Map(IEnumerable<Review> fromValues, IList<ReviewDto> toValues)
        {
            if (fromValues == null)
                throw new ArgumentNullException("fromValues", "fromValues is null.");

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
