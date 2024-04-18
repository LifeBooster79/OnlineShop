using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_BuyerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_SellerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "sellerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "buyerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "BuyerId");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "SellerId1");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "BuyerId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_SellerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "IX_OrderHeader_SellerId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_BuyerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "IX_OrderHeader_BuyerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_AspNetUsers_BuyerId1",
                schema: "sale",
                table: "OrderHeader",
                column: "BuyerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_AspNetUsers_SellerId1",
                schema: "sale",
                table: "OrderHeader",
                column: "SellerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_BuyerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_SellerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "sellerId");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                schema: "sale",
                table: "OrderHeader",
                newName: "buyerId");

            migrationBuilder.RenameColumn(
                name: "SellerId1",
                schema: "sale",
                table: "OrderHeader",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "BuyerId1",
                schema: "sale",
                table: "OrderHeader",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_SellerId1",
                schema: "sale",
                table: "OrderHeader",
                newName: "IX_OrderHeader_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_BuyerId1",
                schema: "sale",
                table: "OrderHeader",
                newName: "IX_OrderHeader_BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_AspNetUsers_BuyerId",
                schema: "sale",
                table: "OrderHeader",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_AspNetUsers_SellerId",
                schema: "sale",
                table: "OrderHeader",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
