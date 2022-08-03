using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookData.Migrations
{
    public partial class SellBuyEditionMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Ship_Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Email_id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "Buyer_Id",
                value: 2);

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "Id", "Adress", "Book_Id", "City", "Country", "Email_id", "First_name", "Last_name", "Password", "Phone", "Ship_Adress", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "chicago st 12", 1, "chicago", "USA", 1, "jimmy", "butler", "butlercode", "05632458", "cleveland", "chicago", 111 },
                    { 2, "minisota st 22", 2, "minisota", "USA", 2, "zach", "lavin", "lavinecode", "05688499", "minisota", "minisota", 220 }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Adress", "Book_Id", "City", "Country", "Discount", "Email_id", "First_name", "Last_name", "Password", "Phone", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "orelance st 22", 1, "orelance", "USA", 0, 1, "ball", "lanzo", "ballcode", "05900779", "orelance", 112 },
                    { 2, "phonex st 22", 2, "phonex", "USA", 0, 2, "paul", "chris", "chriscode", "05998779", "phonex", 442 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Buyers_BuyerId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Sellers_SellerId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Sellers");

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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "Buyer_Id",
                value: 1);
        }
    }
}
