using ProFinder.Core.Entities;
using ProFinder.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Mappers
{
    public static class DtoToCustomerMapper
    {

        public static void Map(CustomerDto fromValue, Customer toValue)
        {
            if (fromValue == null)
                throw new ArgumentException("Argument cannot be null", "fromValue");

            if (toValue == null)
                throw new ArgumentException("Argument cannot be null", "toValue");

            toValue.FirstName = fromValue.Name;
            toValue.LastName = fromValue.LastName;
            toValue.Email = fromValue.Email;
        }


    }
}

