using CRUDPOC.Domain.models;
using Microsoft.EntityFrameworkCore;

namespace CRUDPOC.Data.EfCore5.Configure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
    }
}