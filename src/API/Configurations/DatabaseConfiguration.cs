using Core.Entities;
using Core.Interfaces;
using Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations;

public static class DatabaseConfiguration
{
  public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(options =>
    {
      string connection = GetConnection(configuration);

      options.UseSqlServer(connection,
        x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
    });

    services.AddIdentity<User, IdentityRole>()
      .AddDefaultTokenProviders()
      .AddEntityFrameworkStores<AppDbContext>();

    AppDbContext context = services.BuildServiceProvider().GetRequiredService<AppDbContext>();

    if (context.Database.CanConnect())
    {
      RoleManager<IdentityRole> roleManager = services.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole>>();
      UserManager<User> userManager = services.BuildServiceProvider().GetRequiredService<UserManager<User>>();

      var _ = new DefaultDataMigration(context)
        .MigrateSkillTag()
        .MigrateLevel()
        .MigratePosition()
        .MigrateDepartment()
        .MigrateRole(roleManager)
        .MigrateSystemUser(userManager, configuration);
    }

    services.AddScoped<IAppDbContext, AppDbContext>();

    return services;
  }

  private static string GetConnection(IConfiguration configuration)
  {
    string server = configuration["DB:Server"] ?? "127.0.0.1";
    string port = configuration["DB:Port"] ?? "1433";
    string database = configuration["DB:Name"] ?? "RecruitDb";
    string uid = configuration["DB:UID"] ?? "sa";
    string pwd = configuration["DB:PWD"] ?? "M1ng@2002";

    return $"Server={server},{port};Database={database};UID={uid};PWD={pwd}";
  }
}