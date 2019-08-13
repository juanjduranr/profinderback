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
                throw new ArgumentException("Argument cannot be null", "fromValue");

            if (toValue == null)
                throw new ArgumentException("Argument cannot be null", "toValue");

            toValue.Id = fromValue.Id;
            toValue.Description = fromValue.Description;
            toValue.Name = fromValue.Name;
            toValue.FoundedDate = fromValue.FoundedDate;
            toValue.CostPerHour = fromValue.CostPerHour;
            toValue.NumberOfEmployees = fromValue.NumberOfEmployees;
            toValue.BusinessDays = fromValue.BusinessDays;
            toValue.BusinessHours = fromValue.BusinessHours;
            toValue.ImageUrl = fromValue.ImageUrl;
            toValue.CompanyTypeId = fromValue.CompanyType.Id;
            toValue.CompanyTypeName = fromValue.CompanyType.Name;
            toValue.TotalReviews = fromValue.Reviews.Count();
            toValue.Rating = fromValue.Reviews.WeightedAverage();
            if (includeReviews)
            {
                ReviewToDtoMapper.Map(fromValue.Reviews, toValue.Reviews);
            }
        }

        public static void Map(IEnumerable<Company> fromValues, IList<CompanyDto> toValues, bool includeReviews = false)
        {
            if (fromValues == null)
                throw new ArgumentNullException("fromValues is null.", "fromValues");

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
