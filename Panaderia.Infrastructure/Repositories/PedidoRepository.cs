using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Context;
using Panaderia.Infrastructure.Core;
using Panaderia.Infrastructure.Interfaces;


namespace Panaderia.Infrastructure.Repositories
{
	public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
	{
		public PedidoRepository(PanaderiaContext context)
		: base(context)
		{
		}
	}
}
