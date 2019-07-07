using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int ReviewsCount { get; set; }
        public int Rating { get; set; }
    }
}
