using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    /// <inheritdoc />
    public partial class Contrasenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DireccionCliente",
                table: "Cliente",
                newName: "Contrasenha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contrasenha",
                table: "Cliente",
                newName: "DireccionCliente");
        }
    }
}
