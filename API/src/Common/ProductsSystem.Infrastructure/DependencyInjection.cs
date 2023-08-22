using System;
using ProductsSystem.Application.Common.Interfaces;
using ProductsSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductsSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)//, IWebHostEnvironment environment)
        {
            var provider = configuration.GetValue("DbProvider", "SqlServer");
            var migrationAssembly = $"ProductsSystem.Api";
            services.AddDbContext<ApplicationDbContext>(options => _ = provider switch
            {
                "SqlServer" => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(migrationAssembly);
                        b.EnableRetryOnFailure();
                    }),

                _ => throw new Exception($"Unsupported provider: {provider}")
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}
