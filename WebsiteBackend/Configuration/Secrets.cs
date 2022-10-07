using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using Microsoft.Extensions.Configuration;

namespace WebsiteBackend.Configuration;
public static class Secrets
{
    public static void Configure(IConfigurationRoot config)
    {
        var VaultUri = config["Values:VAULT_URL"];

        if (VaultUri == null)
            return;

        var options = new SecretClientOptions()
        {
            Retry = {
                Delay = TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
            }
        };

        var client = new SecretClient(new Uri(VaultUri), new DefaultAzureCredential(), options);

        var DatabaseConnectionString = client.GetSecret("Trees-Databases-Cosmos-ConnectionString").Value.Value;
        var DatabaseName = client.GetSecret("Trees-Databases-Cosmos-Ipe-Name").Value.Value;

        config["Values:Database:ConnectionString"] = DatabaseConnectionString;
        config["Values:Database:Name"] = DatabaseName;
    }
}