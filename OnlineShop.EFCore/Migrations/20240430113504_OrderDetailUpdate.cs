using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class OrderDetailUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDatePersian",
                schema: "sale",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "sale",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifyDatePersian",
                schema: "sale",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoftDeleteDatePersian",
                schema: "sale",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                schema: "sale",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDatePersian",
                schema: "sale",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "sale",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ModifyDatePersian",
                schema: "sale",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "SoftDeleteDatePersian",
                schema: "sale",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "isModified",
                schema: "sale",
                table: "OrderDetail");
        }
    }
}
