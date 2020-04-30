using Microsoft.EntityFrameworkCore;

namespace StarterWebApplication.Tests.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static DbContext DetachAll(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }

            return context;
        }
    }
}