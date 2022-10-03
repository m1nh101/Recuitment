namespace API.Configurations;

public static class CorsConfiguration
{
  public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddCors(setup =>
    {
      setup.AddPolicy("cors", options =>
      {
        options.AllowAnyHeader()
          .AllowCredentials()
          .AllowAnyMethod()
          .WithOrigins(configuration["CLIENT_ORIGIN"]);
      });
    });

    return services;
  }
}