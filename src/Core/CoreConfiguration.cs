using Core.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core;

public static class CoreConfiguration
{
  public static IServiceCollection ConfigureCoreServices(this IServiceCollection services)
  {
    Assembly currentAssembly = Assembly.GetExecutingAssembly();

    services.AddAutoMapper(currentAssembly);
    services.AddMediatR(currentAssembly);
    services.AddValidatorsFromAssembly(currentAssembly);

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>));

    return services;
  }
}