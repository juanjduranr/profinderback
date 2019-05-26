using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Domain
{
    public interface IUnitOfWork
    {
        int Save();
    }
}
