using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProFinder.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ServiceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    WriterId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "emiller@email.com", "Emma", "Miller" },
                    { 2, "mdavis@email.com", "Michael", "Davis" },
                    { 3, "swilson@email.com", "Sophia", "Wilson" },
                    { 4, "ljones@email.com", "Liam", "Jones" },
                    { 5, "ebrown@email.com", "Emily", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pet sitting" },
                    { 2, "Computer repair" },
                    { 3, "Cleaners" },
                    { 4, "Handyman" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name", "ServiceTypeId", "StartDate" },
                values: new object[,]
                {
                    { 13, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "JD pet services", 1, new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Pet care", 1, new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Pet lovers", 1, new DateTime(2016, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Tech experts", 2, new DateTime(2015, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "IT solutions", 2, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Fast computer repair", 2, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Cleaning pros", 3, new DateTime(2005, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Cleaning services", 3, new DateTime(2010, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Dedicated cleaning", 3, new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Alpha cleaners", 3, new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Clean solutions", 3, new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Fix it", 4, new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Handyman services", 4, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Fast repair", 4, new DateTime(2012, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "Home improvement", 4, new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CompanyId", "Date", "Rating", "WriterId" },
                values: new object[] { 1, "Excelent service!", 2, new DateTime(2019, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ServiceTypeId",
                table: "Companies",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CompanyId",
                table: "Reviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WriterId",
                table: "Reviews",
                column: "WriterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
