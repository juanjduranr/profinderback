using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Extensions
{
    public static class Extensions
    {
        public static int GetExternalId(this ClaimsPrincipal claimsPrincipal)
        {
            var externalId = claimsPrincipal.Claims.Where(c => c.Type == "sub")
                                                  .Select(c => c.Value)
                                                  .SingleOrDefault();

            if (string.IsNullOrEmpty(externalId))
                throw new ArgumentException("External id claim cannot be null", "sub");

            return Convert.ToInt32(externalId);
        }
    }
}
