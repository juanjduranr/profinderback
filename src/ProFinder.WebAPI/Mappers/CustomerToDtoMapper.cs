using ProFinder.Core.Entities;
using ProFinder.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Mappers
{
    public static class CustomerToDtoMapper
    {
        public static void Map(Customer fromValue, CustomerDto toValue)
        {
            if (fromValue == null)
                throw new ArgumentException("Argument cannot be null", "fromValue");

            if (toValue == null)
                throw new ArgumentException("Argument cannot be null", "toValue");

            toValue.ExternalId = fromValue.ExternalId;
            toValue.Name = fromValue.FirstName;
            toValue.LastName = fromValue.LastName;
            toValue.Email = fromValue.Email;            
        }
    }
}
