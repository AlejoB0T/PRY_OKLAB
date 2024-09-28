using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    /// <inheritdoc />
    public partial class fkProveedoresProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Proveedor_ProveedorIdProveedor",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_TipoDocumento_TipoDocumentoIdTipoDocumento",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_TipoDocumentoIdTipoDocumento",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ProveedorIdProveedor",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoIdTipoDocumento",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "ProveedorIdProveedor",
                table: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdTipoDocumento",
                table: "Proveedor",
                column: "IdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdProveedor",
                table: "Producto",
                column: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Proveedor_IdProveedor",
                table: "Producto",
                column: "IdProveedor",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_TipoDocumento_IdTipoDocumento",
                table: "Proveedor",
                column: "IdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "IdTipoDocumento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Proveedor_IdProveedor",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_TipoDocumento_IdTipoDocumento",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_IdTipoDocumento",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdProveedor",
                table: "Producto");

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoIdTipoDocumento",
                table: "Proveedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorIdProveedor",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_TipoDocumentoIdTipoDocumento",
                table: "Proveedor",
                column: "TipoDocumentoIdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProveedorIdProveedor",
                table: "Producto",
                column: "ProveedorIdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Proveedor_ProveedorIdProveedor",
                table: "Producto",
                column: "ProveedorIdProveedor",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_TipoDocumento_TipoDocumentoIdTipoDocumento",
                table: "Proveedor",
                column: "TipoDocumentoIdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "IdTipoDocumento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
