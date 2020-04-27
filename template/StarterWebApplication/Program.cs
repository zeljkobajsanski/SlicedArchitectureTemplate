using System;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarterWebApplication.Helpers;
using StarterWebApplication.Persistence;

namespace StarterWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "StarterWebApplication";
            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(options =>
            {
                var host = CreateHostBuilder(args).Build();
                if (options.MigrateDatabase)
                {
                    using var scope = host.Services.CreateScope();
                    scope.ServiceProvider.GetRequiredService<StarterWebApplicationContext>()
                        .Database.Migrate();
                }
                host.Run();
            });
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}