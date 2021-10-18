using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Car_carid",
                table: "ShopCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "itemId",
                table: "ShopCartItems");

            migrationBuilder.RenameTable(
                name: "ShopCartItems",
                newName: "ShopCartItem");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItems_carid",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_carid");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ShopCartId",
                table: "ShopCartItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem",
                column: "carid",
                principalTable: "Car",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");

            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "ShopCartItem");

            migrationBuilder.RenameTable(
                name: "ShopCartItem",
                newName: "ShopCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_carid",
                table: "ShopCartItems",
                newName: "IX_ShopCartItems_carid");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "ShopCartItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "itemId",
                table: "ShopCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Car_carid",
                table: "ShopCartItems",
                column: "carid",
                principalTable: "Car",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
