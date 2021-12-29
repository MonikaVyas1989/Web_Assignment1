using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Assignment1.Migrations
{
    public partial class SomeSeededdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Swedish" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Denish" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Norwegian" });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "LanguageId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
