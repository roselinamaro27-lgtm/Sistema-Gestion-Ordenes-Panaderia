using Panaderia.Domain.Core;

namespace Panaderia.Domain.Entities
{
	public class DetallePedido : BaseEntity
	{
		public int PedidoId { get; set; }
		public int ProductoId { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
	}
}
