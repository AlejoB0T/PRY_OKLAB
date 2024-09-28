using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionLlaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoDocumento_TipoDocumentoIdTipoDocumento",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DocumentoCliente",
                table: "Clientes",
                column: "DocumentoCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdTipoDocumento",
                table: "Clientes",
                column: "IdTipoDocumento");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_Clientes_DocumentoCliente",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdTipoDocumento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "DocumentoCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoDocumento_TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                column: "TipoDocumentoIdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "IdTipoDocumento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
