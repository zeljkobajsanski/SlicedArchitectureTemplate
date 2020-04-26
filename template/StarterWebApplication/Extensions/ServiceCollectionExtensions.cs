using System.Reflection;
using AutoMapper;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarterWebApplication.Persistence;

namespace StarterWebApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
        public static IServiceCollection AddThirdPartyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddFluentValidation(new[] {Assembly.GetExecutingAssembly()});
            return serviceCollection;
        }

        public static IServiceCollection AddPersistenceModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<StarterWebApplicationContext>(builder =>
            {
                builder.UseSqlite("Data Source=StarterWebApplicationContext.db");
            });
            return serviceCollection;
        }
    }
}