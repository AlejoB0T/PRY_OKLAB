﻿// <auto-generated />
using System;
using CrudCoreOklab.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudCoreOklab.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240808023427_ResetPassword")]
    partial class ResetPassword
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudCoreOklab.Models.Cargo", b =>
                {
                    b.Property<int>("IdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCargo"));

                    b.Property<string>("NombreCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCargo");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CelularCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenha")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("DocumentoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoDocumento")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordResetToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordResetTokenExpiration")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCliente");

                    b.HasIndex("DocumentoCliente")
                        .IsUnique();

                    b.HasIndex("IdTipoDocumento");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("ARL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidoEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CargoIdCargo")
                        .HasColumnType("int");

                    b.Property<string>("CelularEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContrasenhaEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentoEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EPS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDocumento")
                        .HasColumnType("int");

                    b.Property<DateTime>("InicioContrato")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoSangre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("CargoIdCargo");

                    b.HasIndex("IdTipoDocumento");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Habitacion", b =>
                {
                    b.Property<int>("IdHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHabitacion"));

                    b.Property<string>("NombreHabitacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHabitacion");

                    b.ToTable("Habitacion");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("NombreHabitacion")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdCliente");

                    b.HasIndex("NombreHabitacion");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.ReservaAdmon", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<int>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<int>("Eliminar")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("NombreHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("Reservar")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("NombreHabitacion");

                    b.ToTable("ReservasAdmon");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.TipoDocumento", b =>
                {
                    b.Property<int>("IdTipoDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoDocumento"));

                    b.Property<string>("NombreTipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoDocumento");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Cliente", b =>
                {
                    b.HasOne("CrudCoreOklab.Models.TipoDocumento", "TipoDocumento")
                        .WithMany("Cliente")
                        .HasForeignKey("IdTipoDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Empleado", b =>
                {
                    b.HasOne("CrudCoreOklab.Models.Cargo", "Cargo")
                        .WithMany("Empleados")
                        .HasForeignKey("CargoIdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrudCoreOklab.Models.TipoDocumento", "TipoDocumento")
                        .WithMany("Empleado")
                        .HasForeignKey("IdTipoDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Reserva", b =>
                {
                    b.HasOne("CrudCoreOklab.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrudCoreOklab.Models.Habitacion", "Habitacion")
                        .WithMany("Reserva")
                        .HasForeignKey("NombreHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.ReservaAdmon", b =>
                {
                    b.HasOne("CrudCoreOklab.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrudCoreOklab.Models.Habitacion", "Habitacion")
                        .WithMany("ReservasAdmon")
                        .HasForeignKey("NombreHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Cargo", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Habitacion", b =>
                {
                    b.Navigation("Reserva");

                    b.Navigation("ReservasAdmon");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.TipoDocumento", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });
#pragma warning restore 612, 618
        }
    }
}
