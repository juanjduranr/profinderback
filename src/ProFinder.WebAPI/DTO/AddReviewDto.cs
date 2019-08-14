using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.DTO
{
    public class AddReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
    }
}
