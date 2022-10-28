using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebsiteBackend.Configuration;

[assembly: FunctionsStartup(typeof(WebsiteBackend.Startup))]
namespace WebsiteBackend;
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        Secrets.Configure(config);
        Databases.Configure(builder, config);
        Repositories.Configure(builder);
        UseCase.Configure(builder);
    }
}