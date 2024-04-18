using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_BuyerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_SellerId",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "sellerId",
                schema: "sale",
                table: "OrderHeader",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "buyerId",
                schema: "sale",
                table: "OrderHeader",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_BuyerId",
                schema: "sale",
                table: "OrderHeader",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_SellerId",
                schema: "sale",
                table: "OrderHeader",
                column: "SellerId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_BuyerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_SellerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_BuyerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_SellerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "SellerId",
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

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_BuyerId",
                schema: "sale",
                table: "OrderHeader",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_SellerId",
                schema: "sale",
                table: "OrderHeader",
                column: "SellerId");

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
