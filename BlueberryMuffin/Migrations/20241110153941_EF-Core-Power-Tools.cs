using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlueberryMuffin.Migrations
{
    /// <inheritdoc />
    public partial class EFCorePowerTools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8430c817-eb80-47d6-b067-4089c93ed50e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2e6349b-7c95-4d35-9d7a-6ee44d2936b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9f5b298-6da3-4c10-be6f-91a8da8bb51f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d7f2d20-3039-457a-8bce-0d862e863576", null, "Administrator", "ADMIN" },
                    { "6a36c1db-dc86-4e07-a6c0-547246cf083d", null, "User", "USER" },
                    { "e4f3125e-646e-4947-ac33-3cf7a1e27a6c", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d7f2d20-3039-457a-8bce-0d862e863576");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a36c1db-dc86-4e07-a6c0-547246cf083d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f3125e-646e-4947-ac33-3cf7a1e27a6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8430c817-eb80-47d6-b067-4089c93ed50e", null, "Administrator", "ADMIN" },
                    { "f2e6349b-7c95-4d35-9d7a-6ee44d2936b8", null, "User", "USER" },
                    { "f9f5b298-6da3-4c10-be6f-91a8da8bb51f", null, "Manager", "MANAGER" }
                });
        }
    }
}
