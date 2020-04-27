using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarterWebApplication.Extensions;
using StarterWebApplication.Persistence;

namespace StarterWebApplication.Tests.Infrastructure.IoC
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var services = new ServiceCollection();
            services.AddCustomServices().AddThirdPartyServices();
            services.AddScoped(c =>
            {
                var connection = new SqliteConnection("Data Source=:memory:");
                connection.Open();
                var optionsBuilder = new DbContextOptionsBuilder<StarterWebApplicationContext>();
                optionsBuilder.UseSqlite(connection);
                var context = new StarterWebApplicationContext(optionsBuilder.Options);
                context.Database.EnsureCreated();
                return context;
            });
            builder.Populate(services);
        }
    }
}