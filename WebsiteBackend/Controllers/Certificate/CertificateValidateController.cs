using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebsiteBackend.Controllers.Certificate.DTOs;
using WebsiteBackend.Domain.Exceptions;
using WebsiteBackend.UseCases;
using WebsiteBackend.UseCases.CertificateValidate;

namespace WebsiteBackend.Controllers.Certificate;
public class CertificateValidateController
{
    private readonly IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput> _useCase;

    public CertificateValidateController(
        IUseCase<CertificateValidateUseCaseInput, CertificateValidateUseCaseOutput> useCase
    )
    {
        _useCase = useCase;
    }

    public async Task<ObjectResult> Run(CertificateValidateInput certificate)
    {
        try
        {
            var Data = await _useCase
            .Run(new CertificateValidateUseCaseInput()
            {
                CertificateId = certificate.CertificateId
            });

            return new ObjectResult(Data);
        }
        catch (BaseException e)
        {
            return new NotFoundObjectResult(e.Data);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}