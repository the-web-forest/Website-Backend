
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebsiteBackend.Controllers;
using WebsiteBackend.UseCases;
using WebsiteBackend.UseCases.CertificateValidate;

[assembly: FunctionsStartup(typeof(WebsiteBackend.Startup))]

namespace WebsiteBackend
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput>, CertificateValidateUseCase>();

            builder.Services.AddSingleton<CertificateValidateController>();
        }
    }
}