using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Assignment1.Migrations
{
    public partial class AddedRoleandUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
