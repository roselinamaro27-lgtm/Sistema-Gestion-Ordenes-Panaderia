using Microsoft.AspNetCore.Mvc;
using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Interfaces;
using Panaderia.Infrastructure.Models;

namespace Panaderia.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteRepository _repository;

		public ClienteController(IClienteRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var clientes = await _repository.GetAllAsync();

			return Ok(clientes.Select(c => new ClienteDTO
			{
				Id = c.Id,
				Nombre = c.Nombre,
				Telefono = c.Telefono,
				Direccion = c.Direccion
			}));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var cliente = await _repository.GetByIdAsync(id);

			if (cliente == null)
				return NotFound();

			return Ok(new ClienteDTO
			{
				Id = cliente.Id,
				Nombre = cliente.Nombre,
				Telefono = cliente.Telefono,
				Direccion = cliente.Direccion
			});
		}

		[HttpPost]
		public async Task<IActionResult> Create(ClienteDTO dto)
		{
			var cliente = new Cliente
			{
				Nombre = dto.Nombre,
				Telefono = dto.Telefono,
				Direccion = dto.Direccion
			};

			await _repository.AddAsync(cliente);

			return Ok(cliente);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, ClienteDTO dto)
		{
			var cliente = await _repository.GetByIdAsync(id);

			if (cliente == null)
				return NotFound();

			cliente.Nombre = dto.Nombre;
			cliente.Telefono = dto.Telefono;
			cliente.Direccion = dto.Direccion;

			await _repository.UpdateAsync(cliente);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var cliente = await _repository.GetByIdAsync(id);

			if (cliente == null)
				return NotFound();

			await _repository.DeleteAsync(id);

			return NoContent();
		}
	}
}