using Microsoft.EntityFrameworkCore;
using SistemaGestionOrdenesPanaderia.Models;

namespace SistemaGestionOrdenesPanaderia.Data
{
	public class PanaderiaContext : DbContext
	{
		public PanaderiaContext(DbContextOptions<PanaderiaContext> options)
			: base(options)
		{
		}

		public DbSet<Producto> Productos { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<DetallePedido> DetallesPedido { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Producto>()
				.Property(p => p.Precio)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Pedido>()
				.Property(p => p.Total)
				.HasPrecision(10, 2);

			modelBuilder.Entity<DetallePedido>()
				.Property(p => p.Precio)
				.HasPrecision(10, 2);
		}
	}
}