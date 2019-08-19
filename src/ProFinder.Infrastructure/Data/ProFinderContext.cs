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

            modelBuilder.Entity<Customer>()
                        .HasIndex(u => u.ExternalId)
                        .IsUnique();

            modelBuilder.Entity<CompanyType>().HasData(
                new CompanyType { Id = 1, Name = "Pet sitting" },
                new CompanyType { Id = 2, Name = "Computer repair" },
                new CompanyType { Id = 3, Name = "Cleaners" },
                new CompanyType { Id = 4, Name = "Handyman" }
            );

            modelBuilder.Entity<Company>().HasData(
                new { Id = 1, Name = "Fix it", Description = "Repairs, installation, maintenance, assembly and Painting", FoundedDate = new DateTime(2015, 08, 01), NumberOfEmployees = 10, CostPerHour = 80.00m, BusinessDays = "Mon - Fry", BusinessHours = "9:00 a.m. to 5:00 p.m.", CompanyTypeId = 4, ImageUrl = "http://i.imgur.com/A0dRRH7.jpg" },
                new { Id = 2, Name = "Best repair", Description = "General construction services and repairs, design and maintenance", FoundedDate = new DateTime(1990, 06, 01), NumberOfEmployees = 50, CostPerHour = 110.00m, BusinessDays = "Mon - Sat", BusinessHours = "8:00 a.m. to 7:00 p.m.", CompanyTypeId = 4, ImageUrl = "http://i.imgur.com/qKRk812.jpg" },
                new { Id = 3, Name = "Fast repair", Description = "Well prepared staff of handyman and the right resources to do a great work", FoundedDate = new DateTime(2012, 10, 01), NumberOfEmployees = 8, CostPerHour = 55.00m, BusinessDays = "Mon - Sat", BusinessHours = "9:00 a.m. to 6:00 p.m.", CompanyTypeId = 4, ImageUrl = "http://i.imgur.com/3LewfuQ.jpg" },
                new { Id = 4, Name = "Home improvement", Description = "Our service is efficient, professional and low cost", FoundedDate = new DateTime(2018, 03, 01), NumberOfEmployees = 5, CostPerHour = 39.00m, BusinessDays = "Mon - Fry", BusinessHours = "8:00 a.m. to 5:00 p.m.", CompanyTypeId = 4, ImageUrl = "https://i.imgur.com/DyXF5UZ.jpg" },
                new { Id = 5, Name = "Residential Cleaning", Description = "Best cleaning service in town", FoundedDate = new DateTime(2005, 02, 01), NumberOfEmployees = 4, CostPerHour = 35.00m, BusinessDays = "Daily", BusinessHours = "6:00 a.m. to 4:00 p.m.", CompanyTypeId = 3, ImageUrl = "http://i.imgur.com/8GKAgCU.jpg" },
                new { Id = 6, Name = "Home cleaning", Description = "Experience in Cleaning Houses, Apartments, Hotels, Offices, Whorehouse, Moving, packing and unpacking, organization Houses", FoundedDate = new DateTime(2010, 07, 01), NumberOfEmployees = 2, CostPerHour = 25.00m, BusinessDays = "Mon - Fry", BusinessHours = "7:00 a.m. to 9:00 p.m", CompanyTypeId = 3, ImageUrl = "http://i.imgur.com/wgwuBID.jpg" },
                new { Id = 7, Name = "Dedicated cleaning", Description = "We has more than a decade of experience providing high quality residential and commercial cleaning services", FoundedDate = new DateTime(2007, 11, 01), NumberOfEmployees = 25, CostPerHour = 70.00m, BusinessDays = "Mon - Fry", BusinessHours = "7:00 a.m. to 6:00 p.m.", CompanyTypeId = 3, ImageUrl = "http://i.imgur.com/SlOBG3A.jpg" },
                new { Id = 8, Name = "Alpha cleaners", Description = "We take great pride in our attention to health and safety, staying up to date with regular training in the latest cleaning agents and methods", FoundedDate = new DateTime(2015, 12, 01), NumberOfEmployees = 10, CostPerHour = 30.00m, BusinessDays = "Daily", BusinessHours = "8:00 a.m. to 5:00 p.m.", CompanyTypeId = 3, ImageUrl = "http://i.imgur.com/oej3XwX.jpg" },
                new { Id = 9, Name = "Z cleaning services", Description = "If you’re in need of home cleaning, apartment cleaning, or a maid service, we’re simply your best option and most convenient home cleaning service out there", FoundedDate = new DateTime(2016, 05, 01), NumberOfEmployees = 15, CostPerHour = 60.00m, BusinessDays = "Daily", BusinessHours = "8:00 a.m. to 5:00 p.m.", CompanyTypeId = 3, ImageUrl = "https://i.imgur.com/QQE9mII.jpg" },
                new { Id = 10, Name = "Tech experts", Description = "We are fast, reliable, certified and Affordable", FoundedDate = new DateTime(2015, 04, 01), NumberOfEmployees = 4, CostPerHour = 45.00m, BusinessDays = "Mon - Fry", BusinessHours = "9:00 a.m. to 5:00 p.m.", CompanyTypeId = 2, ImageUrl = "https://i.imgur.com/sltuRmG.jpg" },
                new { Id = 11, Name = "Computer repair", Description = "Having problems with your PC, or any other I.T. related matter? Our technicians specialize in I.T.services", FoundedDate = new DateTime(2017, 01, 01), NumberOfEmployees = 3, CostPerHour = 40.00m, BusinessDays = "Mon - Fry", BusinessHours = "9:00 a.m. to 5:00 p.m.", CompanyTypeId = 2, ImageUrl = "http://i.imgur.com/r3814DQ.jpg" },
                new { Id = 12, Name = "Fast computer repair", Description = "We help clients with ease when they think the world is about to end since their computer is not working right", FoundedDate = new DateTime(2018, 05, 01), NumberOfEmployees = 2, CostPerHour = 40.00m, BusinessDays = "Mon - Fry", BusinessHours = "9:00 a.m. to 5:00 p.m.", CompanyTypeId = 2, ImageUrl = "http://i.imgur.com/tAYRXuu.jpg" },
                new { Id = 13, Name = "JD pet services", Description = "I’m reliable and responsible. I take care of every animal as if it were my own.", FoundedDate = new DateTime(2017, 05, 01), NumberOfEmployees = 1, CostPerHour = 25.00m, BusinessDays = "Daily", BusinessHours = "9:00 a.m. to 6:00 p.m.", CompanyTypeId = 1, ImageUrl = "http://i.imgur.com/I9wegW9.jpg" },
                new { Id = 14, Name = "Pet care", Description = "Treat your dog or cat to a mobile pet grooming experience like no other.", FoundedDate = new DateTime(2018, 10, 01), NumberOfEmployees = 5, CostPerHour = 35.00m, BusinessDays = "Daily", BusinessHours = "9:00 a.m. to 6:00 p.m.", CompanyTypeId = 1, ImageUrl = "http://i.imgur.com/VmFBJ2k.jpg" },
                new { Id = 15, Name = "Animal care", Description = "Professional pet sitter", FoundedDate = new DateTime(2016, 12, 01), NumberOfEmployees = 2, CostPerHour = 30.00m, BusinessDays = "Daily", BusinessHours = "9:00 a.m. to 6:00 p.m.", CompanyTypeId = 1, ImageUrl = "http://i.imgur.com/WAhHW1C.jpg" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Miller", Email = "jmiller@email.com", ExternalId = 1 },
                new Customer { Id = 2, FirstName = "Michael", LastName = "Davis", Email = "mdavis@email.com", ExternalId = 2 },
                new Customer { Id = 3, FirstName = "Sophia", LastName = "Wilson", Email = "swilson@email.com", ExternalId = 3 },
                new Customer { Id = 4, FirstName = "Liam", LastName = "Jones", Email = "ljones@email.com", ExternalId = 4 },
                new Customer { Id = 5, FirstName = "Emily", LastName = "Brown", Email = "ebrown@email.com", ExternalId = 5 }
            );

            modelBuilder.Entity<Review>().HasData(
                new { Id = 1, Comment = "Excelent service!", Date = new DateTime(2019, 02, 14), Rating = 5, CustomerId = 1, CompanyId = 1 },
                new { Id = 2, Comment = "Good service!", Date = new DateTime(2019, 01, 05), Rating = 4, CustomerId = 2, CompanyId = 1 },
                new { Id = 3, Comment = "Awesome service!", Date = new DateTime(2019, 03, 01), Rating = 5, CustomerId = 3, CompanyId = 1 },
                new { Id = 4, Comment = "Nice service!", Date = new DateTime(2019, 01, 06), Rating = 4, CustomerId = 4, CompanyId = 1 },
                new { Id = 5, Comment = "Regular service", Date = new DateTime(2019, 02, 20), Rating = 2, CustomerId = 5, CompanyId = 1 },
                new { Id = 6, Comment = "Regular service", Date = new DateTime(2019, 06, 10), Rating = 4, CustomerId = 2, CompanyId = 2 },
                new { Id = 7, Comment = "Not recommended.", Date = new DateTime(2019, 01, 17), Rating = 5, CustomerId = 3, CompanyId = 2 },
                new { Id = 8, Comment = "Bad service", Date = new DateTime(2019, 05, 21), Rating = 4, CustomerId = 4, CompanyId = 2 },
                new { Id = 9, Comment = "Regular service", Date = new DateTime(2019, 02, 18), Rating = 2, CustomerId = 5, CompanyId = 2 },
                new { Id = 10, Comment = "Excelent service!", Date = new DateTime(2019, 01, 08), Rating = 5, CustomerId = 1, CompanyId = 7 },
                new { Id = 11, Comment = "Good service!", Date = new DateTime(2019, 01, 09), Rating = 4, CustomerId = 2, CompanyId = 7 },
                new { Id = 12, Comment = "Awesome service!", Date = new DateTime(2019, 01, 07), Rating = 4, CustomerId = 3, CompanyId = 7 },
                new { Id = 13, Comment = "Excelent service!", Date = new DateTime(2019, 04, 20), Rating = 4, CustomerId = 4, CompanyId = 12 },
                new { Id = 14, Comment = "Fast and good service!", Date = new DateTime(2019, 05, 28), Rating = 4, CustomerId = 5, CompanyId = 12 },                
                new { Id = 15, Comment = "Good service!", Date = new DateTime(2019, 05, 28), Rating = 4, CustomerId = 1, CompanyId = 15 }
            );
        }


    }
}
