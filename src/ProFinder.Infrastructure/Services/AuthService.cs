using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using ProFinder.Core.Entities;
using ProFinder.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProFinder.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Token> GetTokenAsync(User user)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(_configuration["idsrvConfig:url"]);
            if (disco.IsError)
            {
                throw new ArgumentException("Invalid identityServer URL", "idsrvConfig:url");
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = _configuration["idsrvConfig:clientId"],
                ClientSecret = _configuration["idsrvConfig:clientSecret"],
                Scope = _configuration["idsrvConfig:scope"],
                UserName = user.Name,
                Password = user.Password
            });

            if (tokenResponse.IsError)
            {
                return new Token(tokenResponse.Error, tokenResponse.ErrorDescription);
            }

            return new Token(tokenResponse.AccessToken, tokenResponse.ExpiresIn, tokenResponse.RefreshToken);
        }
    }
}
