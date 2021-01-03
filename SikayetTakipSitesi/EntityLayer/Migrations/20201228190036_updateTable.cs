using Microsoft.EntityFrameworkCore.Migrations;

namespace SikayetTakipSitesi.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Countries_CountryId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Members_CountryId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_CountryId",
                table: "Members",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Countries_CountryId",
                table: "Members",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
