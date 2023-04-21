using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Contracts.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("dbCleanArchCqrs")));
        
        services.AddScoped<ICategoryRepository,CategoryRepository>();

        return services;
    }
}