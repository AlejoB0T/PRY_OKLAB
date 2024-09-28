using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.IdTipoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    DocumentoCliente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CelularCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumentoIdTipoDocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.DocumentoCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoDocumento_TipoDocumentoIdTipoDocumento",
                        column: x => x.TipoDocumentoIdTipoDocumento,
                        principalTable: "TipoDocumento",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                column: "TipoDocumentoIdTipoDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoDocumento");
        }
    }
}
