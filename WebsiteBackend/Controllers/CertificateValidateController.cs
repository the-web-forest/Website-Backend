using System;
using System.Threading.Tasks;
using System.Web.Http;
using WebsiteBackend.UseCases;
using WebsiteBackend.UseCases.CertificateValidate;

namespace WebsiteBackend.Controllers
{
    public class CertificateValidateController
    {
        private readonly IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput> _useCase;

        public CertificateValidateController(IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput> useCase)
        {
            _useCase = useCase;
        }

        public async Task<string> Run()
        {
            var Output = await _useCase.Run(new CertificateValidateUseCaseInput());
            return "String Vinda do Controller || " + Output.Response;
        }
    }
}

