using System.Reflection;
using Application.Interfaces.Public;
using Application.Interfaces.Security;
using Application.Interfaces.Validation;
using Application.Models.Email;
using Infrastructures.Public;
using Infrastructures.Security;
using Infrastructures.Validation;
using MGH.Core.CrossCutting.Logging.Serilog;
using MGH.Core.CrossCutting.Logging.Serilog.Logger;
using MGH.Core.ElasticSearch;
using MGH.Core.Mailing;
using MGH.Core.Mailing.MailKitImplementations;
using MGH.Core.Security.EmailAuthenticator;
using MGH.Core.Security.JWT;
using MGH.Core.Security.OtpAuthenticator;
using MGH.Core.Security.OtpAuthenticator.OtpNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructuresServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IValidationService, ValidationService>();
        services.AddTransient<IValidationTool, FluentValidationTool>();
        services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddTransient<IAuthenticatorService, AuthenticatorManager>();
        services.AddTransient<IAuthService, AuthManager>();
        services.AddTransient<ImageServiceBase,CloudinaryImageServiceAdapter>();
        services.AddTransient<IOperationClaimService, OperationClaimManager>();
        services.AddTransient<IUserService, UserManager>();
        services.AddTransient<IUserOperationClaimService, UserUserOperationClaimManager>();
        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        
        return services;
    }
}