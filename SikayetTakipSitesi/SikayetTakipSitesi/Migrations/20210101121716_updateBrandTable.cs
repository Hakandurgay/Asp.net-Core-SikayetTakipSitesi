using Microsoft.EntityFrameworkCore.Migrations;

namespace SikayetTakipSitesi.Migrations
{
    public partial class updateBrandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandContent",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandContent",
                table: "Brands");
        }
    }
}
