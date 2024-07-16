using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdNameOfTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "IdItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdItems",
                table: "Items",
                newName: "Id");
        }
    }
}
