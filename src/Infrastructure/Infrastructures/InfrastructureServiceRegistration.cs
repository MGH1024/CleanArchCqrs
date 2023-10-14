using System.Reflection;
using Application.Interfaces;
using Application.Interfaces.Public;
using Application.Interfaces.Security;
using Application.Interfaces.Validation;
using Application.Models;
using Application.Models.Email;
using Infrastructures.Public;
using Infrastructures.Security;
using Infrastructures.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructuresServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IValidationService, ValidationService>();
        services.AddTransient<IValidationTool, FluentValidationTool>();
        
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IUserService, UserService>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}