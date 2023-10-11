using Application.Contracts.Infrastructure;
using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Infrastructure.Validation;
using Application.Models;
using Application.Models.Email;
using Infrastructures.Identity;
using Infrastructures.Mail;
using Infrastructures.Security;
using Infrastructures.TimeProvider;
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
        return services;
    }
}