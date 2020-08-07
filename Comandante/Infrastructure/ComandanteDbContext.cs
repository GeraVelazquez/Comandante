using Comandante.Model;
using Microsoft.EntityFrameworkCore;

namespace Comandante.Infrastructure
{
    public class ComandanteDbContext : DbContext
    {
        public ComandanteDbContext(DbContextOptions<ComandanteDbContext> options) : base(options)
        {

        }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<AreasServicio> AreasServicio { get; set; }
        public DbSet<Productos> Productos { get; set; }
    }
}
