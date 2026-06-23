using ATI.ProjectPrueba.Classlibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATI.ProjectPrueba.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
