using MongoDB.Driver;
using System.Threading.Tasks;
using WebsiteBackend.Domain.Models;
using WebsiteBackend.UseCases.Interfaces;

namespace WebsiteBackend.External.Repositories;
public class CertificateRepository : BaseRepository<Certificate>, ICertificateRepository
{
    public CertificateRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase) { }

    public async Task<Certificate> FindCertificateByCertificateId(string certificateId)
    {
        return await _collection
           .Find(x => x.CertificateId == certificateId)
           .FirstOrDefaultAsync();
    }
}
