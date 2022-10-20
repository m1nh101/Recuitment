using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Configurations;

public static class AuthConfiguration
{
  public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
  {
    services.Configure<IdentityOptions>(config =>
    {
      config.Password.RequireNonAlphanumeric = false;
      config.Password.RequireDigit = true;
      config.Password.RequireUppercase = false;
      config.Password.RequiredLength = 6;
    });

    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      options.RequireHttpsMetadata = false;
      options.SaveToken = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SECRET_KEY"]))
      };
      options.Events = new JwtBearerEvents
      {
        OnMessageReceived = (context) =>
        {
          string token = context.Request.Cookies["token"] ?? string.Empty;

          if (!string.IsNullOrEmpty(token))
            context.Token = token;

          return Task.CompletedTask;
        }
      };
    });

    return services;
  }
}
