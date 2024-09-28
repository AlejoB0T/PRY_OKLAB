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
    [Migration("20240617220744_ClienteReserva")]
    partial class ClienteReserva
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudCoreOklab.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelularCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("DocumentoCliente")
                        .IsUnique();

                    b.HasIndex("IdTipoDocumento");

                    b.ToTable("Cliente");
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

            modelBuilder.Entity("CrudCoreOklab.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.Habitacion", b =>
                {
                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("CrudCoreOklab.Models.TipoDocumento", b =>
                {
                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
