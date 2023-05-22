using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp_Act17.Server.Migrations
{
    /// <inheritdoc />
    public partial class Migración_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Ventas_VentasId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentasId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VentasId",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedoresId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresId",
                table: "Productos",
                column: "ProveedoresId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "ProductosVentas");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedoresId",
                table: "Productos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_Productos_Proveedores_ProveedoresId",
                table: "Productos",
                column: "ProveedoresId",
                principalTable: "Proveedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Ventas_VentasId",
                table: "Productos",
                column: "VentasId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }
    }
}
