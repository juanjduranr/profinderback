using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProFinder.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExternalId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FoundedDate = table.Column<DateTime>(nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    CostPerHour = table.Column<decimal>(nullable: false),
                    BusinessDays = table.Column<string>(nullable: true),
                    BusinessHours = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CompanyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_CompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pet sitting" },
                    { 2, "Computer repair" },
                    { 3, "Cleaners" },
                    { 4, "Handyman" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "ExternalId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jmiller@email.com", 1, "John", "Miller" },
                    { 2, "mdavis@email.com", 2, "Michael", "Davis" },
                    { 3, "swilson@email.com", 3, "Sophia", "Wilson" },
                    { 4, "ljones@email.com", 4, "Liam", "Jones" },
                    { 5, "ebrown@email.com", 5, "Emily", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "BusinessDays", "BusinessHours", "CompanyTypeId", "CostPerHour", "Description", "FoundedDate", "ImageUrl", "Name", "NumberOfEmployees" },
                values: new object[,]
                {
                    { 13, "Daily", "9:00 a.m. to 6:00 p.m.", 1, 25.00m, "I’m reliable and responsible. I take care of every animal as if it were my own.", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/I9wegW9.jpg", "JD pet services", 1 },
                    { 14, "Daily", "9:00 a.m. to 6:00 p.m.", 1, 35.00m, "Treat your dog or cat to a mobile pet grooming experience like no other.", new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/VmFBJ2k.jpg", "Pet care", 5 },
                    { 15, "Daily", "9:00 a.m. to 6:00 p.m.", 1, 30.00m, "Professional pet sitter", new DateTime(2016, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/WAhHW1C.jpg", "Animal care", 2 },
                    { 10, "Mon - Fry", "9:00 a.m. to 5:00 p.m.", 2, 45.00m, "We are fast, reliable, certified and Affordable", new DateTime(2015, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/sltuRmG.jpg", "Tech experts", 4 },
                    { 11, "Mon - Fry", "9:00 a.m. to 5:00 p.m.", 2, 40.00m, "Having problems with your PC, or any other I.T. related matter? Our technicians specialize in I.T.services", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/r3814DQ.jpg", "Computer repair", 3 },
                    { 12, "Mon - Fry", "9:00 a.m. to 5:00 p.m.", 2, 40.00m, "We help clients with ease when they think the world is about to end since their computer is not working right", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/tAYRXuu.jpg", "Fast computer repair", 2 },
                    { 5, "Daily", "6:00 a.m. to 4:00 p.m.", 3, 35.00m, "Best cleaning service in town", new DateTime(2005, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/8GKAgCU.jpg", "Residential Cleaning", 4 },
                    { 6, "Mon - Fry", "7:00 a.m. to 9:00 p.m", 3, 25.00m, "Experience in Cleaning Houses, Apartments, Hotels, Offices, Whorehouse, Moving, packing and unpacking, organization Houses", new DateTime(2010, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/wgwuBID.jpg", "Home cleaning", 2 },
                    { 7, "Mon - Fry", "7:00 a.m. to 6:00 p.m.", 3, 70.00m, "We has more than a decade of experience providing high quality residential and commercial cleaning services", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/SlOBG3A.jpg", "Dedicated cleaning", 25 },
                    { 8, "Daily", "8:00 a.m. to 5:00 p.m.", 3, 30.00m, "We take great pride in our attention to health and safety, staying up to date with regular training in the latest cleaning agents and methods", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/oej3XwX.jpg", "Alpha cleaners", 10 },
                    { 9, "Daily", "8:00 a.m. to 5:00 p.m.", 3, 60.00m, "If you’re in need of home cleaning, apartment cleaning, or a maid service, we’re simply your best option and most convenient home cleaning service out there", new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/QQE9mII.jpg", "Z cleaning services", 15 },
                    { 1, "Mon - Fry", "9:00 a.m. to 5:00 p.m.", 4, 80.00m, "Repairs, installation, maintenance, assembly and Painting", new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/A0dRRH7.jpg", "Fix it", 10 },
                    { 2, "Mon - Sat", "8:00 a.m. to 7:00 p.m.", 4, 110.00m, "General construction services and repairs, design and maintenance", new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/qKRk812.jpg", "Best repair", 50 },
                    { 3, "Mon - Sat", "9:00 a.m. to 6:00 p.m.", 4, 55.00m, "Well prepared staff of handyman and the right resources to do a great work", new DateTime(2012, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://i.imgur.com/3LewfuQ.jpg", "Fast repair", 8 },
                    { 4, "Mon - Fry", "8:00 a.m. to 5:00 p.m.", 4, 39.00m, "Our service is efficient, professional and low cost", new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/DyXF5UZ.jpg", "Home improvement", 5 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Comment", "CompanyId", "CustomerId", "Date", "Rating" },
                values: new object[,]
                {
                    { 15, "Good service!", 15, 1, new DateTime(2019, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 13, "Excelent service!", 12, 4, new DateTime(2019, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 14, "Fast and good service!", 12, 5, new DateTime(2019, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, "Excelent service!", 7, 1, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 11, "Good service!", 7, 2, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, "Awesome service!", 7, 3, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 1, "Excelent service!", 1, 1, new DateTime(2019, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, "Good service!", 1, 2, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, "Awesome service!", 1, 3, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 4, "Nice service!", 1, 4, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, "Regular service", 1, 5, new DateTime(2019, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, "Regular service", 2, 2, new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, "Not recommended.", 2, 3, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 8, "Bad service", 2, 4, new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, "Regular service", 2, 5, new DateTime(2019, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyTypeId",
                table: "Company",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ExternalId",
                table: "Customer",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_CompanyId",
                table: "Review",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CustomerId",
                table: "Review",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CompanyType");
        }
    }
}
