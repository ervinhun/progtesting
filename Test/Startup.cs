
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        Program.ConfigureServices(services);
        
        //Replace the DbContext with one made for testing
        services.RemoveAll(typeof(MyDbContext));
        services.AddScoped<MyDbContext>(provider =>
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlite(connection)
                .Options;
            var context = new MyDbContext(options);
            context.Database.EnsureCreated();
            return context;
        });
        
    }
}