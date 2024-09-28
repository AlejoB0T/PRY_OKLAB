using Microsoft.EntityFrameworkCore;

namespace CrudCoreOklab.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReservaAdmon> ReservasAdmon { get; set; }
    }
}