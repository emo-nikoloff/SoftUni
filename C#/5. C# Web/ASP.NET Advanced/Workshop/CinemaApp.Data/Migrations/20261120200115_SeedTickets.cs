using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Price", "ProjectionId" },
                values: new object[,]
                {
                    { new Guid("f1a2b3c4-d5e6-4789-a012-3456789abcde"), 12.50m, new Guid("b1f4a8d2-3c67-4e90-8a15-6d2f7c9b0e41") },
                    { new Guid("a2b3c4d5-e6f7-4890-ab12-3456789abcde"), 12.50m, new Guid("e6c2b9f7-1a54-4d83-b028-9f7e3c6a5d12") },
                    { new Guid("b3c4d5e6-f7a8-4901-bc23-456789abcdef"), 12.50m, new Guid("8d3f6b1a-5e92-47c0-a684-2b9f7d4e1c53") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4789-a012-3456789abcde"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a2b3c4d5-e6f7-4890-ab12-3456789abcde"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b3c4d5e6-f7a8-4901-bc23-456789abcdef"));
        }
    }
}
