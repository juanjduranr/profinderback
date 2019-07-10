using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Entities
{
    public class CompanyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Company> Companies { get; set; }

        public CompanyType()
        {
            Companies = new List<Company>();
        }
    }
}