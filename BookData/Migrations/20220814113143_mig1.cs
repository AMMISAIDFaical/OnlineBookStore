using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookData.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Buyers_BuyerId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Sellers_SellerId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BuyerId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_SellerId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BuyerId",
                table: "Book",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SellerId",
                table: "Book",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Buyers_BuyerId",
                table: "Book",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Sellers_SellerId",
                table: "Book",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }
    }
}
