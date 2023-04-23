using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Contracts.Persistence;
using Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
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
            .AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConfig));

        services.AddScoped<ICategoryRepository,CategoryRepository>();

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}