using Microsoft.EntityFrameworkCore;
using StarterWebApplication.Persistence;

namespace StarterWebApplication.Tests.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static StarterWebApplicationContext DetachAll(this StarterWebApplicationContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }

            return context;
        }
    }
}