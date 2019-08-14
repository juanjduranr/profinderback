using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProFinder.AuthIdsrv
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var customProfile = new IdentityResource(
            name: "custom.profile",
            displayName: "Custom Profile",
            claimTypes: new[] { JwtClaimTypes.PreferredUserName });

            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                customProfile
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("profinder", "Pro Finder Inc.", new[] { JwtClaimTypes.PreferredUserName })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "profinder_react_client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("Ub9efngDat_Evrzn6DM8D_Qm7uNJmsPT".Sha256())
                    },
                    AllowedScopes =
                    {
                        "profinder",
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.StandardScopes.OpenId
                    },
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "user",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("preferred_username", "Juan Duran")
                    }
                }
            };
        }
    }
}