using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class updateVentaDetalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_Items_ItemsId",
                table: "VentaDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_PreV_IdPrev",
                table: "VentaDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentaDetalles",
                table: "VentaDetalles");

            migrationBuilder.RenameTable(
                name: "VentaDetalles",
                newName: "Ventas");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalles_ItemsId",
                table: "Ventas",
                newName: "IX_Ventas_ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalles_IdPrev",
                table: "Ventas",
                newName: "IX_Ventas_IdPrev");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas",
                column: "VentaDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Items_ItemsId",
                table: "Ventas",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "IdItems",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_PreV_IdPrev",
                table: "Ventas",
                column: "IdPrev",
                principalTable: "PreV",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Items_ItemsId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_PreV_IdPrev",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas");

            migrationBuilder.RenameTable(
                name: "Ventas",
                newName: "VentaDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ItemsId",
                table: "VentaDetalles",
                newName: "IX_VentaDetalles_ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_IdPrev",
                table: "VentaDetalles",
                newName: "IX_VentaDetalles_IdPrev");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentaDetalles",
                table: "VentaDetalles",
                column: "VentaDId");

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
    }
}
