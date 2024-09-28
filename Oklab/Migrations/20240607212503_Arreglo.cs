using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    /// <inheritdoc />
    public partial class Arreglo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoDocumento_IdTipoDocumento",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoDocumento_TipoDocumentoIdTipoDocumento",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_TipoDocumentoIdTipoDocumento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoIdTipoDocumento",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_IdTipoDocumento",
                table: "Cliente",
                newName: "IX_Cliente_IdTipoDocumento");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_DocumentoCliente",
                table: "Cliente",
                newName: "IX_Cliente_DocumentoCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_TipoDocumento_IdTipoDocumento",
                table: "Cliente",
                column: "IdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "IdTipoDocumento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_TipoDocumento_IdTipoDocumento",
                table: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_IdTipoDocumento",
                table: "Clientes",
                newName: "IX_Clientes_IdTipoDocumento");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_DocumentoCliente",
                table: "Clientes",
                newName: "IX_Clientes_DocumentoCliente");

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                column: "TipoDocumentoIdTipoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoDocumento_IdTipoDocumento",
                table: "Clientes",
                column: "IdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "IdTipoDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoDocumento_TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                column: "TipoDocumentoIdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "IdTipoDocumento");
        }
    }
}
