using ProFinder.Core.Entities;
using ProFinder.Core.Extensions;
using ProFinder.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Mappers
{
    public static class CompanyToDtoMapper
    {
        public static void Map(Company fromValue, CompanyDto toValue, bool includeReviews = false)
        {
            if (fromValue == null)
                throw new ArgumentException("fromValue", "Argument cannot be null");

            if (toValue == null)
                throw new ArgumentException("toValue", "Argument cannot be null");

            toValue.Id = fromValue.Id;
            toValue.Description = fromValue.Description;
            toValue.Name = fromValue.Name;
            toValue.FoundedDate = fromValue.FoundedDate;
            toValue.CostPerHour = fromValue.CostPerHour;
            toValue.NumberOfEmployees = fromValue.NumberOfEmployees;
            toValue.CompanyTypeId = fromValue.CompanyType.Id;
            toValue.CompanyTypeName = fromValue.CompanyType.Name;
            toValue.Rating = fromValue.Reviews.WeightedAverage();    
            if (includeReviews)
                toValue.Reviews = fromValue.Reviews.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    Comment = r.Comment,
                    Date = r.Date,
                    Rating = r.Rating,
                    CustomerName = $"{r.Customer.FirstName} {r.Customer.LastName}"
                }).ToList();            
        }

        public static void Map(IEnumerable<Company> fromValues, IList<CompanyDto> toValues, bool includeReviews = false)
        {
            if (fromValues == null)
                throw new ArgumentNullException("fromValues", "fromValues is null.");

            CompanyDto toValue;

            foreach (var fromValue in fromValues)
            {
                toValue = new CompanyDto();

                Map(fromValue, toValue, includeReviews);

                toValues.Add(toValue);
            }
        }
    }
}
