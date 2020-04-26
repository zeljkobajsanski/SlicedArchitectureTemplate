using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StarterWebApplication.Persistence
{
    public class StarterWebApplicationContextFactory : IDesignTimeDbContextFactory<StarterWebApplicationContext>
    {
        public StarterWebApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StarterWebApplicationContext>();
            optionsBuilder.UseSqlite("Data Source=StarterWebApplicationContext.db");
            return new StarterWebApplicationContext(optionsBuilder.Options);
        }
    }
}