using System.Reflection;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped<
        IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
        ValidateBehavior>();

        // adding all validator from current assembly
        // need Fluent.Aspnetcore Package in Application project
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;

    }
}
