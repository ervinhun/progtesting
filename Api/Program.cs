using System.Text.Json.Serialization;
using Database;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureApiServices(builder.Services, builder.Configuration);
        builder.Services.AddOpenApiDocument(config =>
        {
            config.Title = "Pets";
            config.Version = "v1.0.0.1";
            config.Description = "Pets API, database and web app for testing purposes.";
        });
        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            ctx.Database.EnsureCreated();
        }

        app.UseOpenApi();
        app.UseSwaggerUi();
        app.MapControllers();
        app.Run();
    }

    public static void ConfigureApiServices(IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseNpgsql(builderConfiguration.GetValue<string>("Db"));
        });
        services.AddScoped<PetService>();
        
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
    }
}