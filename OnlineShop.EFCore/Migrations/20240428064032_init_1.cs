using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDatePersian",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "sale",
                table: "OrderHeader",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifyDatePersian",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoftDeleteDatePersian",
                schema: "sale",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                schema: "sale",
                table: "OrderHeader",
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
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "ModifyDatePersian",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "SoftDeleteDatePersian",
                schema: "sale",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "isModified",
                schema: "sale",
                table: "OrderHeader");
        }
    }
}
