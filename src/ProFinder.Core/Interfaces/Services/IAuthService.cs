using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProFinder.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Token> GetTokenAsync(User user);
    }
}
