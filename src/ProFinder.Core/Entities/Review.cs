using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }        
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Company Company { get; set; }
    }
}
