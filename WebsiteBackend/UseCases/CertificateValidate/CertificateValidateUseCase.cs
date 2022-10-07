using System.Threading.Tasks;
using WebsiteBackend.Domain.Exceptions;
using WebsiteBackend.UseCases.Interfaces;

namespace WebsiteBackend.UseCases.CertificateValidate;

public class CertificateValidateUseCase : IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput>
{
    private ICertificateRepository _certificateRepository { get; }
    public CertificateValidateUseCase(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }

    public async Task<CertificateValidateUseCaseOutput> Run(CertificateValidateUseCaseInput Input)
    {
        var certificate = await _certificateRepository
            .FindCertificateByCertificateId(Input.CertificateId);

        if (certificate is null)
            throw new InvalidCertificateIdException();

        return new CertificateValidateUseCaseOutput
        {
            Id = certificate.Id,
            Name = certificate.Name,
            CertificateUrl = certificate.File,
            createtAt = certificate.CreatedAt,
            updatedAt = certificate.UpdatedAt
        };
    }
}