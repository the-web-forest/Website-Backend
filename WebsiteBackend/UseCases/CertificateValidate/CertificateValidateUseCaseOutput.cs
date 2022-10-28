using System;

namespace WebsiteBackend.UseCases.CertificateValidate;
public class CertificateValidateUseCaseOutput
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CertificateUrl { get; set; }
    public DateTime createtAt { get; set; }
    public DateTime updatedAt { get; set; }
}