using Application.Interfaces.UnitOfWork;
using Application.Models.Database;
using Domain.Repositories;
using Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,
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
        
        services.AddDbContext<DbContext>(options => options.UseInMemoryDatabase("nArchitecture"));
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        return services;
    }
}