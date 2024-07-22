using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse.Migrations
{
    /// <inheritdoc />
    public partial class RestoreBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_InfoUserVenta_PrevId",
                table: "VentaProductos");

            migrationBuilder.DropTable(
                name: "InfoUserVenta");

            migrationBuilder.CreateTable(
                name: "PreV",
                columns: table => new
                {
                    PrevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreV", x => x.PrevId);
                    table.ForeignKey(
                        name: "FK_PreV_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreV_UserId",
                table: "PreV",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_PreV_PrevId",
                table: "VentaProductos",
                column: "PrevId",
                principalTable: "PreV",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaProductos_PreV_PrevId",
                table: "VentaProductos");

            migrationBuilder.DropTable(
                name: "PreV");

            migrationBuilder.CreateTable(
                name: "InfoUserVenta",
                columns: table => new
                {
                    PrevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoUserVenta", x => x.PrevId);
                    table.ForeignKey(
                        name: "FK_InfoUserVenta_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoUserVenta_UserId",
                table: "InfoUserVenta",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaProductos_InfoUserVenta_PrevId",
                table: "VentaProductos",
                column: "PrevId",
                principalTable: "InfoUserVenta",
                principalColumn: "PrevId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
