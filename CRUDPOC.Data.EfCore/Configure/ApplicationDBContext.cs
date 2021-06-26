using CRUDPOC.Domain.models;
using Microsoft.EntityFrameworkCore;

namespace CRUDPOC.Data.EfCore.Configure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        //public DbSet<Film> Films { get; set; }
        public DbSet<Developer> Developers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Developer>()
                .Property(p => p.Experience)
                .HasColumnType("decimal(18,4)");
        }
    }
}