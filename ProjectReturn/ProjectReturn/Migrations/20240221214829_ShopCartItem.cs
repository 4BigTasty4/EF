using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectReturn.Migrations
{
    /// <inheritdoc />
    public partial class ShopCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetail",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShopCartItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderDetail",
                newName: "Id");
        }
    }
}
