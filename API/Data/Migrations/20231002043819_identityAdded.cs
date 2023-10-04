using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class identityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f6099e5-3e68-4546-8de2-70899cb03f8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698c09e2-0e67-41db-8651-f7b7e145c5fb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7067aa87-89a9-4ba1-9cb0-eafba9d7f86e", null, "Member", "MEMBER" },
                    { "f464c244-afeb-4b25-9372-8257baee9193", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7067aa87-89a9-4ba1-9cb0-eafba9d7f86e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f464c244-afeb-4b25-9372-8257baee9193");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f6099e5-3e68-4546-8de2-70899cb03f8c", null, "Admin", "ADMIN" },
                    { "698c09e2-0e67-41db-8651-f7b7e145c5fb", null, "Member", "MEMBER" }
                });
        }
    }
}
