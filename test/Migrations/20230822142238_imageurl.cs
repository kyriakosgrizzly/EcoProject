using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAnri.Migrations
{
    /// <inheritdoc />
    public partial class imageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 22, 21, 22, 38, 422, DateTimeKind.Local).AddTicks(4890));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 22, 21, 17, 58, 837, DateTimeKind.Local).AddTicks(9386));
        }
    }
}
