using API.Configurations;
using API.Helpers;
using Core;
using Core.Helpers;
using Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureCoreServices();

builder.Services.ConfigureCors(builder.Configuration);

builder.Services.ConfigureAuth(builder.Configuration);

builder.Services.ConfigureEmailClient(builder.Configuration);

builder.Services.ConfigureCookie();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IFileUpload, FileUpload>();

builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddScoped<JwtHelper>();

builder.Services.AddScoped<Util>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();

  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
  });
}

app.UseHttpsRedirection();

app.UseCors("cors");

app.UseCookiePolicy();

app.UseAuthentication();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
