using Microsoft.EntityFrameworkCore.Migrations;

namespace ProFinder.Infrastructure.Migrations
{
    public partial class UpdDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Company",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "http://placeimg.com/200/200/any");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "ExternalId", "FirstName" },
                values: new object[] { "jmiller@email.com", 1, "John" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExternalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExternalId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExternalId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExternalId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ExternalId",
                table: "Customer",
                column: "ExternalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_ExternalId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Company");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName" },
                values: new object[] { "emiller@email.com", "Emma" });
        }
    }
}
