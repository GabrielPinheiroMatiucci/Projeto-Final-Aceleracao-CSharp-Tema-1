using Tryitter.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Tryitter.Token;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TryitterContext>();
builder.Services.AddScoped<TryitterRepository>();
builder.Services.AddDbContext<TryitterContext>(
  options =>
  {
    string connectionString;

    if (builder.Environment.IsDevelopment())
      connectionString = "server=localhost;port=3333;database=Tryitter;user=root;password=root";
    else
      connectionString = "server=mysqlTryitter;port=3306;database=Tryitter;user=root;password=root";

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
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(
      Encoding.ASCII.GetBytes(TokenConstant.secret)
    )
  };
});

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("Login", p => p.RequireClaim("Role", "Student"));
});

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
app.UseAuthentication();
app.MapControllers();

app.UseCors(c => c
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader()
);

app.Run();

public partial class Program {}