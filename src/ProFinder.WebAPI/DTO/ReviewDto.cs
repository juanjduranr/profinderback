using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }        
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }        
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }        
        public int CompanyId { get; set; }
    }
}
