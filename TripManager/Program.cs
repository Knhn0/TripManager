using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TripManager.DAL;
using TripManager.Models;
using TripManager.Service.Implementations;
using TripManager.Service.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers();

ConfigureServices(builder.Services);

void ConfigureServices(IServiceCollection services)
{
    builder.Services.AddAuthorization();
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.ISSUER,
                ValidateAudience = true,
                ValidAudience = AuthOptions.AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true
            };
        });
    builder.Services.AddSwaggerGen(config =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        config.IncludeXmlComments(xmlPath);
    });
    
    builder.Services.AddTransient<IUserLogic, UserLogic>();
    builder.Services.AddScoped<IUserDomain, UserDomain>();
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<IDataContext, DataContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
}



var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "UserService");
});
app.UseAuthentication().UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();