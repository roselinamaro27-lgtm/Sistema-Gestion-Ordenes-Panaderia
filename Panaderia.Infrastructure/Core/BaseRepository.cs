using Microsoft.EntityFrameworkCore;
using Panaderia.Domain.Core;
using Panaderia.Domain.Repository.Interfaces;
using Panaderia.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.Core
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly PanaderiaContext _context;
		protected readonly DbSet<T> _dbSet;

		public BaseRepository(PanaderiaContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);

			if (entity != null)
			{
				_dbSet.Remove(entity);
				await _context.SaveChangesAsync();
			}
		}
	}
}
