using System.Reflection;
using Application.Behavior;
using Application.Features.Categories.Commands.CreateCategory;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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