using Tryitter.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TryitterContext>();
builder.Services.AddScoped<TryitterRepository>();
builder.Services.AddDbContext<TryitterContext>(
  options =>
  {
    var connectionString = "server=mysqlTryitter;port=3306;database=Tryitter;user=root;password=root";
    var version = ServerVersion.AutoDetect(connectionString);

    options
      .UseMySql( connectionString, new MySqlServerVersion(version))
      .LogTo(Console.WriteLine, LogLevel.Information)
      .EnableSensitiveDataLogging()
      .EnableDetailedErrors();
  }
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var context = services.GetRequiredService<TryitterContext>();
  context.Database.EnsureCreated();
}

//  app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(c => c
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader()
);

app.Run();

public partial class Program {}
