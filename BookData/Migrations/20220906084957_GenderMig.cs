using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookData.Migrations
{
    public partial class GenderMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Sellers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Buyers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Buyers");
        }
    }
}
