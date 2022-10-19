using Core.Interfaces;
using Infrastructure.Email;
using Mailjet.Client;

namespace API.Configurations;

public static class EmailConfiguration
{
  public static IServiceCollection ConfigureEmailClient(this IServiceCollection serivces, IConfiguration configuration)
  {
    serivces.AddHttpClient<IMailjetClient, MailjetClient>(client =>
    {
      string public_key = configuration["MAILJET_PUBLIC_KEY"];
      string private_key = configuration["MAILJET_PRIVATE_KEY"];

      client.SetDefaultSettings();
      client.UseBasicAuthentication(public_key, private_key);
    });

    serivces.AddScoped<IEmailService, EmailService>();

    return serivces;
  }
}