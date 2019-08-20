using ProFinder.Core.Entities;
using ProFinder.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Mappers
{
    public static class TokenToDtoMapper
    {
        public static void Map(Token fromValue, TokenDto toValue)
        {
            if (fromValue == null)
                throw new ArgumentException("Argument cannot be null", "fromValue");

            if (toValue == null)
                throw new ArgumentException("Argument cannot be null", "toValue");

            toValue.AccessToken = fromValue.AccessToken;
            toValue.ExpiresIn = fromValue.ExpiresIn;
            toValue.RefreshToken = fromValue.RefreshToken;
        }
    }
}
