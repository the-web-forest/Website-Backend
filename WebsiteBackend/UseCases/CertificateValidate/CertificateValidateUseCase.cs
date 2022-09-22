using System;
using System.Threading.Tasks;

namespace WebsiteBackend.UseCases.CertificateValidate
{
    public class CertificateValidateUseCase: IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput>
    {
        public CertificateValidateUseCase()
        {
        }

        public Task<CertificateValidateUseCaseOutput> Run(CertificateValidateUseCaseInput Input)
        {
            var Output = new CertificateValidateUseCaseOutput
            {
                Response = "String vinda do UseCase"
            };

            return Task.FromResult(Output);
        }
    }
}

