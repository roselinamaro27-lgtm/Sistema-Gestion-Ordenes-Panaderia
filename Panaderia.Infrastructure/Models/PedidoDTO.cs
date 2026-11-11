namespace Panaderia.Infrastructure.Models
{
	public class PedidoDTO
	{
		public int Id { get; set; }
		public int ClienteId { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Total { get; set; }
		public string Estado { get; set; } = string.Empty;
	}
}