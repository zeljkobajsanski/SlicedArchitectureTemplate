using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace StarterWebApplication.Persistence
{
    public class StarterWebApplicationContext : DbContext
    {
        public StarterWebApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}