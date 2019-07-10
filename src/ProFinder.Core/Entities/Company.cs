using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FoundedDate { get; set; }
        public int NumberOfEmployees { get; set; }
        public decimal CostPerHour { get; set; }
        public CompanyType CompanyType { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public Company()
        {
            Reviews = new List<Review>();
        }
    }
}
