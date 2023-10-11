using Application.Models;
using Application.Models.Database;
using Domain.Repositories;
using Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Persistence.DbContexts;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var sqlConfig = configuration
            .GetSection(nameof(DatabaseConnection))
            .Get<DatabaseConnection>()
            .SqlConnection;
        
        services.AddHealthChecks()
            .AddDbContextCheck<AppDbContext>();

        services
            .AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(sqlConfig, a =>
                    {
                        a.EnableRetryOnFailure();
                        a.MigrationsAssembly("Api");
                    })
                .AddInterceptors()
                .LogTo(Console.Write,LogLevel.Information));

        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}