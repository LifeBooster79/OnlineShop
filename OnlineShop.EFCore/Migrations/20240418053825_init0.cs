using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_BuyerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_SellerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_BuyerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeader_SellerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "BuyerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "SellerId1",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: false,
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_AspNetUsers_SellerId",
                schema: "sale",
                table: "OrderHeader",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                schema: "sale",
                table: "OrderHeader",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                schema: "sale",
                table: "OrderHeader",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BuyerId1",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId1",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_BuyerId1",
                schema: "sale",
                table: "OrderHeader",
                column: "BuyerId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_SellerId1",
                schema: "sale",
                table: "OrderHeader",
                column: "SellerId1");

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
    }
}
