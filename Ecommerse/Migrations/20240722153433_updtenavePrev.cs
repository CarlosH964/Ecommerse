using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerse.Migrations
{
    public partial class updtenavePrev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminar la clave foránea existente
            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_InfoUserVenta_IdPrev",
                table: "VentaProductos");

            migrationBuilder.DropIndex(
                name: "IX_VentaProductos_IdPrev",
                table: "VentaProductos");

            // Añadir nueva columna PrevId
            migrationBuilder.AddColumn<int>(
                name: "PrevId",
                table: "VentaProductos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Crear nuevo índice y clave foránea
            migrationBuilder.CreateIndex(
                name: "IX_VentaProductos_PrevId",
                table: "VentaProductos",
                column: "PrevId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_InfoUserVenta_PrevId",
                table: "VentaProductos",
                column: "PrevId",
                principalTable: "InfoUserVenta",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revertir cambios en caso de necesitar rollback
            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_InfoUserVenta_PrevId",
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
                name: "FK_VentaProductos_InfoUserVenta_IdPrev",
                table: "VentaProductos",
                column: "IdPrev",
                principalTable: "InfoUserVenta",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
