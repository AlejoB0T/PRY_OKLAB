using Microsoft.EntityFrameworkCore;
using CrudCoreOklab.Models;

namespace CrudCoreOklab.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; } // DbSet para Habitacion
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Productos> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.EmailCliente)
                .IsUnique();

            // Configuración de la relación entre Cliente y TipoDocumento
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.TipoDocumento)
                .WithMany(t => t.Cliente)
                .HasForeignKey(c => c.IdTipoDocumento);

            // Configuración de la unicidad del DocumentoCliente
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.DocumentoCliente)
                .IsUnique();

            // Configuración de la relación entre Reserva y Habitacion
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Habitacion)
                .WithMany(h => h.Reserva)
                .HasForeignKey(r => r.NombreHabitacion);

            // Configuración de la relación entre Cliente y Reservas
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Reservas)
                .WithOne(r => r.Cliente)
                .HasForeignKey(r => r.IdCliente);


            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.TipoDocumento)
                .WithMany(t => t.Empleado)
                .HasForeignKey(e => e.IdTipoDocumento);

            modelBuilder.Entity<Proveedor>()
                .HasOne(p => p.TipoDocumento)
                .WithMany(t => t.Proveedor)
                .HasForeignKey(p => p.IdTipoDocumento);

            modelBuilder.Entity<Productos>()
                .HasOne(p => p.Proveedor)
                .WithMany(r => r.Productos)
                .HasForeignKey(p => p.IdProveedor);
        }
    }
}
