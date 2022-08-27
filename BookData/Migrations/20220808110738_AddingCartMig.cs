using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookData.Migrations
{
    public partial class AddingCartMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerBookCartId",
                table: "Buyers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookCartId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_BuyerBookCartId",
                table: "Buyers",
                column: "BuyerBookCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookCartId",
                table: "Book",
                column: "BookCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookCart_BookCartId",
                table: "Book",
                column: "BookCartId",
                principalTable: "BookCart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_BookCart_BuyerBookCartId",
                table: "Buyers",
                column: "BuyerBookCartId",
                principalTable: "BookCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookCart_BookCartId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_BookCart_BuyerBookCartId",
                table: "Buyers");

            migrationBuilder.DropTable(
                name: "BookCart");

            migrationBuilder.DropIndex(
                name: "IX_Buyers_BuyerBookCartId",
                table: "Buyers");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookCartId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BuyerBookCartId",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "BookCartId",
                table: "Book");
        }
    }
}
