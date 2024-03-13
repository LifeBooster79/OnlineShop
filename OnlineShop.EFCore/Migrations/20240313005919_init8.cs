using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_productCategoryId",
                schema: "sale",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "productCategoryId",
                schema: "sale",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedLatin",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 13, 4, 29, 19, 548, DateTimeKind.Local).AddTicks(3808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 13, 4, 26, 56, 263, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_productCategoryId",
                schema: "sale",
                table: "Product",
                column: "productCategoryId",
                principalSchema: "sale",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_productCategoryId",
                schema: "sale",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "productCategoryId",
                schema: "sale",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreatedLatin",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 13, 4, 26, 56, 263, DateTimeKind.Local).AddTicks(3358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 13, 4, 29, 19, 548, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_productCategoryId",
                schema: "sale",
                table: "Product",
                column: "productCategoryId",
                principalSchema: "sale",
                principalTable: "ProductCategory",
                principalColumn: "Id");
        }
    }
}
