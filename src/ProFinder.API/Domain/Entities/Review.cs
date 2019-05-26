using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }        
        public DateTime Date { get; set; }
        public Customer Writer { get; set; }
        public Company Company { get; set; }
    }
}
