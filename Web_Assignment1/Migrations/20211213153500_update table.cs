using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Assignment1.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "City",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityViewModel_CountryViewModel_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityViewModel_CountryId",
                table: "CityViewModel",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_CityViewModel_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "CityViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_CityViewModel_CityId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "CityViewModel");

            migrationBuilder.DropTable(
                name: "CountryViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Persons",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "City", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Göteborg", "David", "+462215424243" },
                    { 2, "Halmstad", "Malin", "+461234455678" },
                    { 3, "Halmstad", "Olga", "+462215424789" },
                    { 4, "Varberg", "Rasool", "+469821542424" }
                });
        }
    }
}
