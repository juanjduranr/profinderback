using Microsoft.EntityFrameworkCore;
using ProFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Infrastructure.Data
{
    public class ProFinderContext : DbContext
    {
        public ProFinderContext(DbContextOptions<ProFinderContext> options) : base(options)
        { }

        public DbSet<Company> Companies  { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Renaming tables name to singular
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<CompanyType>().ToTable("CompanyType");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Review>().ToTable("Review");
        }


    }
}
