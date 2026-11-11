using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Context;
using Panaderia.Infrastructure.Core;
using Panaderia.Infrastructure.Interfaces;

namespace Panaderia.Infrastructure.Repositories
{
	public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
	{
		public ProductoRepository(PanaderiaContext context)
		: base(context)
		{
		}
	}
}
