using Microsoft.AspNetCore.Mvc;
using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Interfaces;
using Panaderia.Infrastructure.Models;

namespace Panaderia.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PedidoController : ControllerBase
	{
		private readonly IPedidoRepository _repository;

		public PedidoController(IPedidoRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var pedidos = await _repository.GetAllAsync();

			return Ok(pedidos.Select(p => new PedidoDTO
			{
				Id = p.Id,
				ClienteId = p.ClienteId,
				Fecha = p.Fecha,
				Total = p.Total,
				Estado = p.Estado
			}));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var pedido = await _repository.GetByIdAsync(id);

			if (pedido == null)
				return NotFound();

			return Ok(new PedidoDTO
			{
				Id = pedido.Id,
				ClienteId = pedido.ClienteId,
				Fecha = pedido.Fecha,
				Total = pedido.Total,
				Estado = pedido.Estado
			});
		}

		[HttpPost]
		public async Task<IActionResult> Create(PedidoDTO dto)
		{
			var pedido = new Pedido
			{
				ClienteId = dto.ClienteId,
				Fecha = dto.Fecha,
				Total = dto.Total,
				Estado = dto.Estado
			};

			await _repository.AddAsync(pedido);

			return Ok(pedido);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, PedidoDTO dto)
		{
			var pedido = await _repository.GetByIdAsync(id);

			if (pedido == null)
				return NotFound();

			pedido.ClienteId = dto.ClienteId;
			pedido.Fecha = dto.Fecha;
			pedido.Total = dto.Total;
			pedido.Estado = dto.Estado;

			await _repository.UpdateAsync(pedido);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var pedido = await _repository.GetByIdAsync(id);

			if (pedido == null)
				return NotFound();

			await _repository.DeleteAsync(id);

			return NoContent();
		}
	}
}