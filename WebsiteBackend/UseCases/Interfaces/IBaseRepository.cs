using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebsiteBackend.Interfaces;
public interface IBaseRepository<T>
{
	Task Create(T Data);
	Task Update(T Data);
	Task CreateMany(List<T> DataList);
}