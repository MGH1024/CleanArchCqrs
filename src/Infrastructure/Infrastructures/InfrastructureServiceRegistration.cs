using Application.Contracts.Infrastructure;
using Application.Contracts.Infrastructure.Validation;
using Application.Models;
using Application.Models.Email;
using Infrastructures.Mail;
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
        return services;
    }
}