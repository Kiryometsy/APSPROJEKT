using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "72142856-f386-4bd9-a132-e62ef6122f5a", "6ecf9db3-36e8-4e7e-8df8-787b37005614" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e256551d-495b-482f-8a17-dd8304440fca", "874265d9-0e9a-4656-846b-9739f722ee46" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72142856-f386-4bd9-a132-e62ef6122f5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e256551d-495b-482f-8a17-dd8304440fca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ecf9db3-36e8-4e7e-8df8-787b37005614");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "874265d9-0e9a-4656-846b-9739f722ee46");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e441687-e5db-4fc2-905e-a1abba16f138", "1e441687-e5db-4fc2-905e-a1abba16f138", "admin", "ADMIN" },
                    { "2b00a8cf-8231-4aa0-ac5c-a542750943d2", "2b00a8cf-8231-4aa0-ac5c-a542750943d2", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bc580956-70f9-4400-a21c-9ce9588a867d", 0, "57b36f5f-7634-4a91-b504-686378aa02c1", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAELr7X78Fvq5M+LLKx4i2ZKtS0+xa18CoPDY/ODJDM06PXi/EPAM59MLQModLv63rrA==", null, false, "f51bc9f1-1757-4a8b-888e-c9f506eb4b03", false, "admin" },
                    { "f94c9ffa-6eed-422b-b0e9-dbacc98d35ee", 0, "3c9476ec-c3b8-4be8-b9dd-4f4483cde035", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEKYiGhTH9JYJIm2buasfYz/gHBF6GkdYxful0+rsdCbhn9O+vZCzQWxskeqJgyeZpw==", null, false, "c702e24f-cf41-437c-ad21-a5ce12c2dcf7", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1e441687-e5db-4fc2-905e-a1abba16f138", "bc580956-70f9-4400-a21c-9ce9588a867d" },
                    { "2b00a8cf-8231-4aa0-ac5c-a542750943d2", "f94c9ffa-6eed-422b-b0e9-dbacc98d35ee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e441687-e5db-4fc2-905e-a1abba16f138", "bc580956-70f9-4400-a21c-9ce9588a867d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2b00a8cf-8231-4aa0-ac5c-a542750943d2", "f94c9ffa-6eed-422b-b0e9-dbacc98d35ee" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e441687-e5db-4fc2-905e-a1abba16f138");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b00a8cf-8231-4aa0-ac5c-a542750943d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc580956-70f9-4400-a21c-9ce9588a867d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94c9ffa-6eed-422b-b0e9-dbacc98d35ee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72142856-f386-4bd9-a132-e62ef6122f5a", "72142856-f386-4bd9-a132-e62ef6122f5a", "admin", "ADMIN" },
                    { "e256551d-495b-482f-8a17-dd8304440fca", "e256551d-495b-482f-8a17-dd8304440fca", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6ecf9db3-36e8-4e7e-8df8-787b37005614", 0, "75a8be35-6d7d-402c-af09-96b1800d66f1", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAEKmXmWBQCbFvEtG6DaBrPV7QChQ7dQDB88smOfE0IuxoEuN6aQqOYeZ/hDdfKkVAPg==", null, false, "6d076889-efc4-4cb5-8b7f-d0cf885148ca", false, "admin" },
                    { "874265d9-0e9a-4656-846b-9739f722ee46", 0, "4994cb62-4970-4514-a6c5-122490bde829", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEH/MtRFreYzUO5bxlJ0BhmTWPoUBBnfeN3anvdpXpTCNkTGagAERlw/BMDysmGWtEw==", null, false, "72a30523-62f2-4e0e-9e25-84c9a374c835", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "72142856-f386-4bd9-a132-e62ef6122f5a", "6ecf9db3-36e8-4e7e-8df8-787b37005614" },
                    { "e256551d-495b-482f-8a17-dd8304440fca", "874265d9-0e9a-4656-846b-9739f722ee46" }
                });
        }
    }
}
