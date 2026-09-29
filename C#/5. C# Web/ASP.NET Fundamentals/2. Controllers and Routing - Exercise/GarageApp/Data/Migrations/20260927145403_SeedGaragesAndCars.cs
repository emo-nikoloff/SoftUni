using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGaragesAndCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia, Bulgaria", "Auto Center Sofia" },
                    { 2, "Plovdiv, Bulgaria", "Plovdiv Motors" },
                    { 3, "Varna, Bulgaria", "Black Sea Garage" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "GarageId", "IsAvailable", "Make", "Model", "ProductionMonth", "Type", "Year" },
                values: new object[,]
                {
                    { 1, 1, true, "Toyota", "Corolla", 5, 1, 2021 },
                    { 2, 1, true, "Volkswagen", "Golf", 9, 0, 2019 },
                    { 3, 2, false, "BMW", "X5", 2, 8, 2022 },
                    { 4, 3, true, "Ford", "Transit", 11, 7, 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
