using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.Categories.Commands.CreateCategories;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(typeof(CreateCategoryCommandHandler).Assembly);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}