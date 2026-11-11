using System;
using Panaderia.Domain.Core;

namespace Panaderia.Domain.Entities
{
	public class Pedido : BaseEntity
	{
		public int ClienteId { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Total { get; set; }
		public string Estado { get; set; } = string.Empty;
	}
}
