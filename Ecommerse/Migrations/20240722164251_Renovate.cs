using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class Renovate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_Items_ItemsId",
                table: "VentaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_PreV_PrevId",
                table: "VentaProductos");

            migrationBuilder.DropIndex(
                name: "IX_VentaProductos_PrevId",
                table: "VentaProductos");

            migrationBuilder.DropColumn(
                name: "PrevId",
                table: "VentaProductos");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProductos_IdPrev",
                table: "VentaProductos",
                column: "IdPrev");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_Items_ItemsId",
                table: "VentaProductos",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "IdItems",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_PreV_IdPrev",
                table: "VentaProductos",
                column: "IdPrev",
                principalTable: "PreV",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_Items_ItemsId",
                table: "VentaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_PreV_IdPrev",
                table: "VentaProductos");

            migrationBuilder.DropIndex(
                name: "IX_VentaProductos_IdPrev",
                table: "VentaProductos");

            migrationBuilder.AddColumn<int>(
                name: "PrevId",
                table: "VentaProductos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VentaProductos_PrevId",
                table: "VentaProductos",
                column: "PrevId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_Items_ItemsId",
                table: "VentaProductos",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "IdItems",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_PreV_PrevId",
                table: "VentaProductos",
                column: "PrevId",
                principalTable: "PreV",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
