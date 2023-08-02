using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice.Infrastructure.Persistance.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e49007ca-44c3-4bff-9658-b02e27cd4597");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc4e2f23-e4c0-4527-a287-1d55f678b941");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Teams",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "118316fd-7794-4ad2-b30b-2ca8801bf505", "aed2d746-f202-4932-a63b-c7e052069aa5", "AppRole", "member", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "70792c2a-1cc2-40c7-88cd-9101831a16a7", "8d3d7a6b-af0b-46a4-b179-7cd9fa9899d5", "AppRole", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Salary",
                table: "Teams");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "e49007ca-44c3-4bff-9658-b02e27cd4597", "5de84040-bff3-41a3-8466-123ad8693a70", "AppRole", "member", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "fc4e2f23-e4c0-4527-a287-1d55f678b941", "96944b0f-7df7-46e0-8e1d-94a7586f7023", "AppRole", "admin", null });
        }
    }
}
