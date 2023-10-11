using Application.Models;
using Application.Models.Database;
using Domain.Repositories;
using Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var sqlConfig = configuration
            .GetSection(nameof(DbConnection))
            .Get<DbConnection>()
            .SqlConnection;
        
        services.AddHealthChecks()
            .AddDbContextCheck<AppDbContext>();
        
        services
            .AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConfig,
                a=>a.MigrationsAssembly("Api")));

        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}