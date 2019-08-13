using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Interfaces
{
    public interface IUnitOfWork
    {
        int Save();
    }
}
