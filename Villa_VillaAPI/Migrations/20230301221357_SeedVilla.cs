using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 56, 874, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 56, 874, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 56, 874, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 56, 874, DateTimeKind.Local).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 56, 874, DateTimeKind.Local).AddTicks(7430));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 33, 94, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 33, 94, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 33, 94, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 33, 94, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 1, 14, 13, 33, 94, DateTimeKind.Local).AddTicks(8547));
        }
    }
}
