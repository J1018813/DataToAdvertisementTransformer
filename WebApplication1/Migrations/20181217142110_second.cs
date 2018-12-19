using Microsoft.EntityFrameworkCore.Migrations;

namespace DataToAdvertisementTransformer.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Keywords");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "KeywordLocations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "KeywordLocations");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Keywords",
                nullable: false,
                defaultValue: 0);
        }
    }
}
