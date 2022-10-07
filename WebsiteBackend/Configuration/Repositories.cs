using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WebsiteBackend.External.Repositories;
using WebsiteBackend.UseCases.Interfaces;

namespace WebsiteBackend.Configuration;

public static class Repositories
{
    public static void Configure(IFunctionsHostBuilder builder)
    {
        #region Certificate
        builder.Services.AddTransient<ICertificateRepository, CertificateRepository>();
        #endregion
    }
}