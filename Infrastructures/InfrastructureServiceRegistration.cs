using Application.Contracts.Infrastructure;
using Application.Models;
using Infrastructures.Mail;
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
        return services;
    }
}