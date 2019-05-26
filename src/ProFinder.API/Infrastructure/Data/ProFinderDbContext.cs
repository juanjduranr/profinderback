using Microsoft.EntityFrameworkCore;
using ProFinder.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFinder.API.Infrastructure.Data
{
    public class ProFinderDbContext : DbContext
    {
        public ProFinderDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType { Id = 1, Name = "Pet sitting" },
                new ServiceType { Id = 2, Name = "Computer repair" },
                new ServiceType { Id = 3, Name = "Cleaners" },                
                new ServiceType { Id = 4, Name = "Handyman" }
            );
            
            modelBuilder.Entity<Company>().HasData(
                new { Id = 1, Name = "Fix it", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2015, 08, 01), ServiceTypeId = 4 },
                new { Id = 2, Name = "Handyman services", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(1990, 06, 01), ServiceTypeId = 4 },
                new { Id = 3, Name = "Fast repair", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2012, 10, 01), ServiceTypeId = 4 },
                new { Id = 4, Name = "Home improvement", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2018, 03, 01), ServiceTypeId = 4 },
                new { Id = 5, Name = "Cleaning pros", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2005, 02, 01), ServiceTypeId = 3 },
                new { Id = 6, Name = "Cleaning services", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2010, 07, 01), ServiceTypeId = 3 },
                new { Id = 7, Name = "Dedicated cleaning", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2013, 11, 01), ServiceTypeId = 3 },
                new { Id = 8, Name = "Alpha cleaners", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2015, 12, 01), ServiceTypeId = 3 },
                new { Id = 9, Name = "Clean solutions", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2016, 05, 01), ServiceTypeId = 3 },
                new { Id = 10, Name = "Tech experts", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2015, 04, 01), ServiceTypeId = 2 },
                new { Id = 11, Name = "IT solutions", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2017, 01, 01), ServiceTypeId = 2 },
                new { Id = 12, Name = "Fast computer repair", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2018, 05, 01), ServiceTypeId = 2 },
                new { Id = 13, Name = "JD pet services", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2017, 05, 01), ServiceTypeId = 1 },
                new { Id = 14, Name = "Pet care", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2018, 10, 01), ServiceTypeId = 1 },
                new { Id = 15, Name = "Pet lovers", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry", StartDate = new DateTime(2016, 12, 01), ServiceTypeId = 1 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Emma", LastName = "Miller", Email = "emiller@email.com"},
                new Customer { Id = 2, FirstName = "Michael", LastName = "Davis", Email = "mdavis@email.com" },
                new Customer { Id = 3, FirstName = "Sophia", LastName = "Wilson", Email = "swilson@email.com" },
                new Customer { Id = 4, FirstName = "Liam", LastName = "Jones", Email = "ljones@email.com" },
                new Customer { Id = 5, FirstName = "Emily", LastName = "Brown", Email = "ebrown@email.com" }
            );

            modelBuilder.Entity<Review>().HasData(
                new { Id = 1, Comment = "Excelent service!", Date = new DateTime(2019, 02, 14), Rating = 5, CustomerId = 1 , CompanyId = 2 }
            );
        }
    }
}
