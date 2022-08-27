using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookData.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_id",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Email_id",
                table: "Buyers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Buyers");

            migrationBuilder.AddColumn<int>(
                name: "Email_id",
                table: "Sellers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Email_id",
                table: "Buyers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
