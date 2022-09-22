using System;
using System.Threading.Tasks;

namespace WebsiteBackend.UseCases
{
    public interface IUseCase<I,O>
    {
        Task<O> Run(I Input);
    }
}

