using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    /// <inheritdoc />
    public partial class IdCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Reserva");
        }
    }
}
