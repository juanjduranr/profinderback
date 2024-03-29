﻿using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetById(int id);
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
    }
}
