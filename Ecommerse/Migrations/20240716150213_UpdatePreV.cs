using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePreV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreV_Users_UserId",
                table: "PreV");

            migrationBuilder.DropIndex(
                name: "IX_PreV_UserId",
                table: "PreV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PreV_UserId",
                table: "PreV",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreV_Users_UserId",
                table: "PreV",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
