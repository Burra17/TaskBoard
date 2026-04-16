using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskBoard.Application.Behaviors;

namespace TaskBoard.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // MediatR handlers
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        // FluentValidation validators
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        // Pipeline behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // AutoMapper profiles
        services.AddAutoMapper(cfg =>
            cfg.AddMaps(typeof(DependencyInjection).Assembly));

        return services;
    }
}
