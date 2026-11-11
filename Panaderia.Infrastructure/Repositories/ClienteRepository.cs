using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Context;
using Panaderia.Infrastructure.Core;
using Panaderia.Infrastructure.Interfaces;


namespace Panaderia.Infrastructure.Repositories
{
	public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
	{
		public ClienteRepository(PanaderiaContext context)
		: base(context)
		{
		}
	}
}
