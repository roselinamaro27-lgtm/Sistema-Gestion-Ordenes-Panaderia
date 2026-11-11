using Microsoft.AspNetCore.Mvc;
using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Interfaces;
using Panaderia.Infrastructure.Models;

namespace Panaderia.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DetallePedidoController : ControllerBase
	{
		private readonly IDetallePedidoRepository _repository;

		public DetallePedidoController(IDetallePedidoRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var detalles = await _repository.GetAllAsync();

			return Ok(detalles.Select(d => new DetallePedidoDTO
			{
				Id = d.Id,
				PedidoId = d.PedidoId,
				ProductoId = d.ProductoId,
				Cantidad = d.Cantidad,
				Precio = d.Precio
			}));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var detalle = await _repository.GetByIdAsync(id);

			if (detalle == null)
				return NotFound();

			return Ok(new DetallePedidoDTO
			{
				Id = detalle.Id,
				PedidoId = detalle.PedidoId,
				ProductoId = detalle.ProductoId,
				Cantidad = detalle.Cantidad,
				Precio = detalle.Precio
			});
		}

		[HttpPost]
		public async Task<IActionResult> Create(DetallePedidoDTO dto)
		{
			var detalle = new DetallePedido
			{
				PedidoId = dto.PedidoId,
				ProductoId = dto.ProductoId,
				Cantidad = dto.Cantidad,
				Precio = dto.Precio
			};

			await _repository.AddAsync(detalle);

			return Ok(detalle);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, DetallePedidoDTO dto)
		{
			var detalle = await _repository.GetByIdAsync(id);

			if (detalle == null)
				return NotFound();

			detalle.PedidoId = dto.PedidoId;
			detalle.ProductoId = dto.ProductoId;
			detalle.Cantidad = dto.Cantidad;
			detalle.Precio = dto.Precio;

			await _repository.UpdateAsync(detalle);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var detalle = await _repository.GetByIdAsync(id);

			if (detalle == null)
				return NotFound();

			await _repository.DeleteAsync(id);

			return NoContent();
		}
	}
}