using Microsoft.EntityFrameworkCore;

namespace StarterWebApplication.Persistence
{
    public class StarterWebApplicationContext : DbContext
    {
        public StarterWebApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}