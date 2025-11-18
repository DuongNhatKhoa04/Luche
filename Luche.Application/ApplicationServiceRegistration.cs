using System.Reflection;
using FluentValidation;
using Luche.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Luche.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}