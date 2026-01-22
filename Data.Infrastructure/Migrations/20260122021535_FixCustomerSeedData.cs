using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCustomerSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CustomerType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CustomerType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CustomerType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2026, 1, 22, 5, 3, 27, 607, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CustomerType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2026, 1, 22, 5, 3, 27, 609, DateTimeKind.Local).AddTicks(547));
        }
    }
}
