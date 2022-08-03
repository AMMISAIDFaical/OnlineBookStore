using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buyer_Id = table.Column<int>(type: "int", nullable: false),
                    Seller_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Buyer_Id", "ISBN", "Publisher", "Seller_Id", "Title" },
                values: new object[] { 1, 1, "111111111", "PUB 1", 1, "BOOK 1" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Buyer_Id", "ISBN", "Publisher", "Seller_Id", "Title" },
                values: new object[] { 2, 1, "111111111", "PUB 2", 2, "BOOK 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
