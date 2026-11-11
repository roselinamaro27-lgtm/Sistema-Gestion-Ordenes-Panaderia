using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Context;
using Panaderia.Infrastructure.Core;
using Panaderia.Infrastructure.Interfaces;

namespace Panaderia.Infrastructure.Repositories
{
	public class DetallePedidoRepository : BaseRepository<DetallePedido>, IDetallePedidoRepository
	{
		public DetallePedidoRepository(PanaderiaContext context)
		: base(context)
		{
		}
	}
}
