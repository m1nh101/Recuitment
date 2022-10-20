using Microsoft.AspNetCore.Identity;

namespace API.Configurations;

public static class AuthConfiguration
{
  public static IServiceCollection ConfigureAuth(this IServiceCollection services)
  {
    services.Configure<IdentityOptions>(config =>
    {
      config.Password.RequireNonAlphanumeric = false;
      config.Password.RequireDigit = true;
      config.Password.RequireUppercase = false;
      config.Password.RequiredLength = 6;
    });

    return services;
  }
}
