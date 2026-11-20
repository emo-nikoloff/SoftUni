using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCinemasAndProjections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("4e8d1c6b-2f75-4a39-b0e6-9c3d5f7a8214"), false, "Varna", "Movie Park" },
                    { new Guid("a7f3b2c8-6e14-4d55-9f2a-1b8c7e6d3a90"), false, "Plovdiv", "Cine Grand" },
                    { new Guid("d2c5e0a1-9c9b-4a80-8d76-5c0e0a4a2f11"), false, "Sofia", "Arena Cinema" }
                });

            migrationBuilder.InsertData(
                table: "Projections",
                columns: new[] { "Id", "AvailableTickets", "CinemaId", "IsDeleted", "MovieId", "Showtime" },
                values: new object[,]
                {
                    { new Guid("8d3f6b1a-5e92-47c0-a684-2b9f7d4e1c53"), 150, new Guid("4e8d1c6b-2f75-4a39-b0e6-9c3d5f7a8214"), false, new Guid("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), new DateTime(2026, 12, 3, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1f4a8d2-3c67-4e90-8a15-6d2f7c9b0e41"), 120, new Guid("d2c5e0a1-9c9b-4a80-8d76-5c0e0a4a2f11"), false, new Guid("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), new DateTime(2026, 12, 1, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6c2b9f7-1a54-4d83-b028-9f7e3c6a5d12"), 100, new Guid("a7f3b2c8-6e14-4d55-9f2a-1b8c7e6d3a90"), false, new Guid("e673a37c-8ffc-46bf-a66d-18b8078d7c94"), new DateTime(2026, 12, 2, 20, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("8d3f6b1a-5e92-47c0-a684-2b9f7d4e1c53"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("b1f4a8d2-3c67-4e90-8a15-6d2f7c9b0e41"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("e6c2b9f7-1a54-4d83-b028-9f7e3c6a5d12"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4e8d1c6b-2f75-4a39-b0e6-9c3d5f7a8214"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("a7f3b2c8-6e14-4d55-9f2a-1b8c7e6d3a90"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("d2c5e0a1-9c9b-4a80-8d76-5c0e0a4a2f11"));
        }
    }
}
