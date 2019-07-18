﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProFinder.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProFinderContext>
    {
        public ProFinderContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile(@Directory.GetCurrentDirectory() +
                                                    "/../ProFinder.API/appsettings.Development.json").Build();
            var builder = new DbContextOptionsBuilder<ProFinderContext>();
            var connectionString = configuration.GetConnectionString("DafaultTwo");
            builder.UseSqlServer(connectionString);
            return new ProFinderContext(builder.Options);
        }
    }
}
