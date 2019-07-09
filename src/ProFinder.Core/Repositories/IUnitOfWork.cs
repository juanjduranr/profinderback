using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Repositories
{
    public interface IUnitOfWork
    {
        int Save();
    }
}
