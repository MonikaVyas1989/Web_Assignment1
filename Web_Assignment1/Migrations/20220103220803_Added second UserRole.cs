using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Assignment1.Migrations
{
    public partial class AddedsecondUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c6de27b0-2295-4c3e-aa97-4f93fddf938a", "ffdb8b1f-93fe-4aae-899e-214568c7d2c1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffdb8b1f-93fe-4aae-899e-214568c7d2c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6de27b0-2295-4c3e-aa97-4f93fddf938a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98eba521-0b2e-4c4d-8dee-5addc37473a7", "9e140c2a-9d5c-48f5-b075-1d8c03faacbc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7a75462-e862-4805-b424-1a95bc185e0f", "b0dab09e-a532-4565-a684-f2b112ca6e86", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "BirthDate", "FirstName", "LastName" },
                values: new object[] { "b4179909-f056-4217-941b-47042b5ab9f5", 0, "2652c497-462e-45d0-8e42-063855ebffc8", "ApplicationUser", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEJZazTjhfqr6QJSGLdU8h+rVW95slBudjcjDwJ18Ycp+O9CgPtM+V6idwaavz5yKCQ==", null, false, "cdc64865-3597-4c6e-ab4e-9c667b975c14", false, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Admission" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4179909-f056-4217-941b-47042b5ab9f5", "98eba521-0b2e-4c4d-8dee-5addc37473a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7a75462-e862-4805-b424-1a95bc185e0f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b4179909-f056-4217-941b-47042b5ab9f5", "98eba521-0b2e-4c4d-8dee-5addc37473a7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98eba521-0b2e-4c4d-8dee-5addc37473a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4179909-f056-4217-941b-47042b5ab9f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffdb8b1f-93fe-4aae-899e-214568c7d2c1", "845439b2-fdc5-44d7-b13c-f41d95f8cb23", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "BirthDate", "FirstName", "LastName" },
                values: new object[] { "c6de27b0-2295-4c3e-aa97-4f93fddf938a", 0, "082f505f-4a8e-46d6-a3e7-ebfeb74d2129", "ApplicationUser", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEE1dH+7YYTN7bpxr4SHlKx6Gb7A41QpD72cMEMR/f2k9HPnNkCavD9QeosgknpUrFA==", null, false, "8337b926-c941-4102-ae77-b5e4efa613c0", false, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Admission" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c6de27b0-2295-4c3e-aa97-4f93fddf938a", "ffdb8b1f-93fe-4aae-899e-214568c7d2c1" });
        }
    }
}
