using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice.Infrastructure.Persistance.Migrations
{
    public partial class changeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e18c59c-ba0a-4617-adf5-d12fd9fa26e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4c17978-82ac-4687-896e-72c72ce9c8b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "792f1233-5f01-4993-af2c-783ff97f3795", "c31b497b-fb89-4b1e-b1b2-f2bcb71545e4", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a47c3068-df12-4a73-b76d-0038b2eaff50", "33674d0d-1b08-4d73-889e-8a6702754ae8", "member", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "792f1233-5f01-4993-af2c-783ff97f3795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a47c3068-df12-4a73-b76d-0038b2eaff50");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e18c59c-ba0a-4617-adf5-d12fd9fa26e4", "981bbd5f-7d50-4585-86da-012a67db398b", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4c17978-82ac-4687-896e-72c72ce9c8b5", "dc572b45-f0f6-4668-95bf-9c34ec8290fc", "member", null });
        }
    }
}
