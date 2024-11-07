using Microsoft.EntityFrameworkCore;
using TiendaPruebaAPI.Models;

namespace TiendaPruebaAPI
{
    public class AppDbContext : DbContext
    {

        public DbSet<Productos> Productos { get; set; }
 
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
