using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WebsiteBackend.Controllers.Certificate;
using WebsiteBackend.UseCases;
using WebsiteBackend.UseCases.CertificateValidate;

namespace WebsiteBackend.Configuration;

public static class UseCase
{
    public static void Configure(IFunctionsHostBuilder builder)
    {
        #region Configuration
        builder.Services.AddSingleton<IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput>, CertificateValidateUseCase>();
        builder.Services.AddSingleton<CertificateValidateController>();
        #endregion
    }
}