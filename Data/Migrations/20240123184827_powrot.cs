using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class powrot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c", "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c", "user", "USER" },
                    { "fe865148-3834-4b34-8f13-9f5d11f37893", "fe865148-3834-4b34-8f13-9f5d11f37893", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "769825a8-cdb6-4694-9cdf-f3c905273227", 0, "64789fa4-c3ae-4353-b859-a35a978ad853", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAELaVuBRhAX5o97CUt1xyvQY5sMTIit2LEsam19ILOcxFAH/wDL/U7TOGi2rCK7nIpA==", null, false, "f586a0f0-22b0-4511-9376-522112465a44", false, "user" },
                    { "dfbace42-9d45-4144-840a-c8242799b052", 0, "ba117028-2f87-47d3-ae1f-602b2331cbc5", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAEPC3TojobZTavhxAIpipjx8l4ZE3iTOW5x8PdeG18Ov8utVnB/E7vXJIGJbID1yZgw==", null, false, "7a384f8a-9539-46f9-8ca7-8226966d7460", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c", "769825a8-cdb6-4694-9cdf-f3c905273227" },
                    { "fe865148-3834-4b34-8f13-9f5d11f37893", "dfbace42-9d45-4144-840a-c8242799b052" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c", "769825a8-cdb6-4694-9cdf-f3c905273227" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe865148-3834-4b34-8f13-9f5d11f37893", "dfbace42-9d45-4144-840a-c8242799b052" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cd75b2f-2b01-4f28-b3eb-7d1d42d17b4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe865148-3834-4b34-8f13-9f5d11f37893");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "769825a8-cdb6-4694-9cdf-f3c905273227");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfbace42-9d45-4144-840a-c8242799b052");

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
    }
}
