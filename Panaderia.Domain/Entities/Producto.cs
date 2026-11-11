using Panaderia.Domain.Core;

namespace Panaderia.Domain.Entities
{
	public class Producto : BaseEntity
	{
		public string Nombre { get; set; } = string.Empty;
		public decimal Precio { get; set; }
		public int Stock { get; set; }
	}
}
