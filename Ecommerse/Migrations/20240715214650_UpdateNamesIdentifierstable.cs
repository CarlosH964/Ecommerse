using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamesIdentifierstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreV_Users_Comprador",
                table: "PreV");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_Items_EcommerceId",
                table: "VentaDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_PreV_VentaId",
                table: "VentaDetalles");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "VentaDetalles",
                newName: "ItemsId");

            migrationBuilder.RenameColumn(
                name: "EcommerceId",
                table: "VentaDetalles",
                newName: "IdPrev");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalles_VentaId",
                table: "VentaDetalles",
                newName: "IX_VentaDetalles_ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalles_EcommerceId",
                table: "VentaDetalles",
                newName: "IX_VentaDetalles_IdPrev");

            migrationBuilder.RenameColumn(
                name: "Comprador",
                table: "PreV",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PreV_Comprador",
                table: "PreV",
                newName: "IX_PreV_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreV_Users_UserId",
                table: "PreV",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_Items_ItemsId",
                table: "VentaDetalles",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "IdItems",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_PreV_IdPrev",
                table: "VentaDetalles",
                column: "IdPrev",
                principalTable: "PreV",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreV_Users_UserId",
                table: "PreV");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_Items_ItemsId",
                table: "VentaDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_PreV_IdPrev",
                table: "VentaDetalles");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "VentaDetalles",
                newName: "VentaId");

            migrationBuilder.RenameColumn(
                name: "IdPrev",
                table: "VentaDetalles",
                newName: "EcommerceId");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalles_ItemsId",
                table: "VentaDetalles",
                newName: "IX_VentaDetalles_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalles_IdPrev",
                table: "VentaDetalles",
                newName: "IX_VentaDetalles_EcommerceId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PreV",
                newName: "Comprador");

            migrationBuilder.RenameIndex(
                name: "IX_PreV_UserId",
                table: "PreV",
                newName: "IX_PreV_Comprador");

            migrationBuilder.AddForeignKey(
                name: "FK_PreV_Users_Comprador",
                table: "PreV",
                column: "Comprador",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_Items_EcommerceId",
                table: "VentaDetalles",
                column: "EcommerceId",
                principalTable: "Items",
                principalColumn: "IdItems",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_PreV_VentaId",
                table: "VentaDetalles",
                column: "VentaId",
                principalTable: "PreV",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
