using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public ServiceType ServiceType { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public Company()
        {
            Reviews = new List<Review>();
        }
    }
}
