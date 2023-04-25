using MediatR;
using FluentValidation;
using System.Reflection;
using Application.Behavior;
using Application.Models.Identity;
using Microsoft.Extensions.DependencyInjection;
using Application.Contracts.Infrastructure.Identity;
using Application.Features.Categories.Commands.CreateCategory;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(typeof(CreateCategoryCommandHandler).Assembly);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), 
            typeof(ValidationBehavior<,>));
        return services;
    }
}