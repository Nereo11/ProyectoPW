using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp_Act17.Server.Migrations
{
    /// <inheritdoc />
    public partial class Migración_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosVentas");

            migrationBuilder.AddColumn<int>(
                name: "VentasId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentasId",
                table: "Productos",
                column: "VentasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Ventas_VentasId",
                table: "Productos",
                column: "VentasId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Ventas_VentasId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentasId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VentasId",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "ProductosVentas",
                columns: table => new
                {
                    ProductosId = table.Column<int>(type: "int", nullable: false),
                    VentasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVentas", x => new { x.ProductosId, x.VentasId });
                    table.ForeignKey(
                        name: "FK_ProductosVentas_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosVentas_Ventas_VentasId",
                        column: x => x.VentasId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVentas_VentasId",
                table: "ProductosVentas",
                column: "VentasId");
        }
    }
}
