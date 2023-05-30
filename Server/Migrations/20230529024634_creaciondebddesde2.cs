using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp_Act17.Server.Migrations
{
    /// <inheritdoc />
    public partial class creaciondebddesde2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresId",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedoresId",
                table: "Productos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresId",
                table: "Productos",
                column: "ProveedoresId",
                principalTable: "Proveedores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedoresId",
                table: "Productos",
                column: "ProveedoresId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
