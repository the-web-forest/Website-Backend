using System.Threading.Tasks;
using WebsiteBackend.Domain.Models;
using WebsiteBackend.Interfaces;

namespace WebsiteBackend.UseCases.Interfaces;
public interface ICertificateRepository : IBaseRepository<Certificate>
{
    Task<Certificate> FindCertificateByCertificateId(string certificateId);
}
