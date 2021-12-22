using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Assignment1.Migrations
{
    public partial class Seededatatables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityViewModel_CountryViewModel_CountryId",
                table: "CityViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_CityViewModel_CityId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryViewModel",
                table: "CountryViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityViewModel",
                table: "CityViewModel");

            migrationBuilder.RenameTable(
                name: "CountryViewModel",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "CityViewModel",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_CityViewModel_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sweden" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Norwe" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Denmark" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Varberg" },
                    { 2, 1, "Halmstad" },
                    { 3, 2, "Oslo" },
                    { 4, 3, "Copenhagen" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "CityId", "Name", "Phone" },
                values: new object[,]
                {
                    { 2, 1, "Malin", "+461234455678" },
                    { 1, 2, "David", "+462215424243" },
                    { 3, 2, "Olga", "+462215424789" },
                    { 4, 3, "Rasool", "+469821542424" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "CountryViewModel");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "CityViewModel");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "CityViewModel",
                newName: "IX_CityViewModel_CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryViewModel",
                table: "CountryViewModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityViewModel",
                table: "CityViewModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CityViewModel_CountryViewModel_CountryId",
                table: "CityViewModel",
                column: "CountryId",
                principalTable: "CountryViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_CityViewModel_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "CityViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
