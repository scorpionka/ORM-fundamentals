using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ORM.Domain.Models;
using ORM.Domain.Repositories;
using ORM.Domain.Repositories.Interfaces;

namespace ORMConsoleApp
{
    public class ProgramServicesProvider
    {
        public static void RunServicesProvider(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            // part of these services can be registered in the corresponding library
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IRepository<Product>, Repository<Product>>();
                    services.AddTransient<IRepository<Order>, Repository<Order>>();
                });
        }
    }
}
