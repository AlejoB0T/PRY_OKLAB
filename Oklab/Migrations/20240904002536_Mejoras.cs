using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    /// <inheritdoc />
    public partial class Mejoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Cargo_CargoIdCargo",
                table: "Empleado");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_CargoIdCargo",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "ARL",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "CargoIdCargo",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "ContrasenhaEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "EPS",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdCargo",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "TipoSangre",
                table: "Empleado",
                newName: "RolEmpleado");

            migrationBuilder.RenameColumn(
                name: "InicioContrato",
                table: "Empleado",
                newName: "FechaNacimientoEmpleado");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentoEmpleado",
                table: "Empleado",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CelularEmpleado",
                table: "Empleado",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ARLEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CajaCompensacionEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CargoEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContraseñaCorporativaEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DireccionEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EPSEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivilEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioContratoEmpleado",
                table: "Empleado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FondoPensionEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JefeInmediatoEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroHijosEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalarioEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoContratoEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoSangreEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCorporativoEmpleado",
                table: "Empleado",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "ARLEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "CajaCompensacionEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "CargoEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "ContraseñaCorporativaEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "DireccionEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "EPSEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "EstadoCivilEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "FechaInicioContratoEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "FondoPensionEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "JefeInmediatoEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "NumeroHijosEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "SalarioEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "TipoContratoEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "TipoSangreEmpleado",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "UsuarioCorporativoEmpleado",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "RolEmpleado",
                table: "Empleado",
                newName: "TipoSangre");

            migrationBuilder.RenameColumn(
                name: "FechaNacimientoEmpleado",
                table: "Empleado",
                newName: "InicioContrato");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpleado",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEmpleado",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CelularEmpleado",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoEmpleado",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ARL",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CargoIdCargo",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContrasenhaEmpleado",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EPS",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdCargo",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.IdCargo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargoIdCargo",
                table: "Empleado",
                column: "CargoIdCargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Cargo_CargoIdCargo",
                table: "Empleado",
                column: "CargoIdCargo",
                principalTable: "Cargo",
                principalColumn: "IdCargo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
