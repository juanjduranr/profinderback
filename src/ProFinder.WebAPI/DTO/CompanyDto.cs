using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.DTO
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FoundedDate { get; set; }
        public int NumberOfEmployees { get; set; }
        public string BusinessDays { get; set; }
        public string BusinessHours { get; set; }
        public decimal CostPerHour { get; set; }
        public double Rating { get; set; }
        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }
        public int TotalReviews { get; set; }
        public List<ReviewDto> Reviews { get; set; }

        public CompanyDto()
        {
            Reviews = new List<ReviewDto>();
        }
    }
}
