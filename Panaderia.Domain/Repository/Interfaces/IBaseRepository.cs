using System.Collections.Generic;
using System.Threading.Tasks;
using Panaderia.Domain.Core;

namespace Panaderia.Domain.Repository.Interfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T?> GetByIdAsync(int id);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(int id);
	}
}
