using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice.Infrastructure.Persistance.Migrations
{
    public partial class updated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "118316fd-7794-4ad2-b30b-2ca8801bf505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70792c2a-1cc2-40c7-88cd-9101831a16a7");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e18c59c-ba0a-4617-adf5-d12fd9fa26e4", "981bbd5f-7d50-4585-86da-012a67db398b", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4c17978-82ac-4687-896e-72c72ce9c8b5", "dc572b45-f0f6-4668-95bf-9c34ec8290fc", "member", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e18c59c-ba0a-4617-adf5-d12fd9fa26e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4c17978-82ac-4687-896e-72c72ce9c8b5");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "118316fd-7794-4ad2-b30b-2ca8801bf505", "aed2d746-f202-4932-a63b-c7e052069aa5", "AppRole", "member", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "70792c2a-1cc2-40c7-88cd-9101831a16a7", "8d3d7a6b-af0b-46a4-b179-7cd9fa9899d5", "AppRole", "admin", null });
        }
    }
}
