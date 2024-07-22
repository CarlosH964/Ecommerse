using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class updatenamesoftables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreV_Users_UserId",
                table: "PreV");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Items_ItemsId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_PreV_IdPrev",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreV",
                table: "PreV");

            migrationBuilder.RenameTable(
                name: "Ventas",
                newName: "VentaProductos");

            migrationBuilder.RenameTable(
                name: "PreV",
                newName: "InfoUserVenta");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ItemsId",
                table: "VentaProductos",
                newName: "IX_VentaProductos_ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_IdPrev",
                table: "VentaProductos",
                newName: "IX_VentaProductos_IdPrev");

            migrationBuilder.RenameIndex(
                name: "IX_PreV_UserId",
                table: "InfoUserVenta",
                newName: "IX_InfoUserVenta_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentaProductos",
                table: "VentaProductos",
                column: "VentaDId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoUserVenta",
                table: "InfoUserVenta",
                column: "PrevId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoUserVenta_Users_UserId",
                table: "InfoUserVenta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_InfoUserVenta_IdPrev",
                table: "VentaProductos",
                column: "IdPrev",
                principalTable: "InfoUserVenta",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_Items_ItemsId",
                table: "VentaProductos",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "IdItems",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoUserVenta_Users_UserId",
                table: "InfoUserVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_InfoUserVenta_IdPrev",
                table: "VentaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_Items_ItemsId",
                table: "VentaProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentaProductos",
                table: "VentaProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoUserVenta",
                table: "InfoUserVenta");

            migrationBuilder.RenameTable(
                name: "VentaProductos",
                newName: "Ventas");

            migrationBuilder.RenameTable(
                name: "InfoUserVenta",
                newName: "PreV");

            migrationBuilder.RenameIndex(
                name: "IX_VentaProductos_ItemsId",
                table: "Ventas",
                newName: "IX_Ventas_ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_VentaProductos_IdPrev",
                table: "Ventas",
                newName: "IX_Ventas_IdPrev");

            migrationBuilder.RenameIndex(
                name: "IX_InfoUserVenta_UserId",
                table: "PreV",
                newName: "IX_PreV_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas",
                column: "VentaDId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreV",
                table: "PreV",
                column: "PrevId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreV_Users_UserId",
                table: "PreV",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

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
    }
}
