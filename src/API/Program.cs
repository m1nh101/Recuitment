using API.Configurations;
using API.Helpers;
using Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureCoreServices();

builder.Services.ConfigureCors(builder.Configuration);

builder.Services.ConfigureAuth();

builder.Services.ConfigureEmailClient(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddScoped<IFileUpload, FileUpload>();

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

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
