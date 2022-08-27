using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookData.Migrations
{
    public partial class AddingRelationToBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BuyerId",
                table: "Book",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Buyers_BuyerId",
                table: "Book",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Buyers_BuyerId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BuyerId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Book");
        }
    }
}
