using Microsoft.AspNetCore.Mvc;
using Panaderia.Domain.Entities;
using Panaderia.Infrastructure.Interfaces;
using Panaderia.Infrastructure.Models;

namespace Panaderia.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductoController : ControllerBase
	{
		private readonly IProductoRepository _repository;

		public ProductoController(IProductoRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var productos = await _repository.GetAllAsync();

			return Ok(productos.Select(p => new ProductoDTO
			{
				Id = p.Id,
				Nombre = p.Nombre,
				Precio = p.Precio,
				Stock = p.Stock
			}));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var producto = await _repository.GetByIdAsync(id);

			if (producto == null)
				return NotFound();

			return Ok(new ProductoDTO
			{
				Id = producto.Id,
				Nombre = producto.Nombre,
				Precio = producto.Precio,
				Stock = producto.Stock
			});
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductoDTO dto)
		{
			var producto = new Producto
			{
				Nombre = dto.Nombre,
				Precio = dto.Precio,
				Stock = dto.Stock
			};

			await _repository.AddAsync(producto);

			return Ok(producto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, ProductoDTO dto)
		{
			var producto = await _repository.GetByIdAsync(id);

			if (producto == null)
				return NotFound();

			producto.Nombre = dto.Nombre;
			producto.Precio = dto.Precio;
			producto.Stock = dto.Stock;

			await _repository.UpdateAsync(producto);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var producto = await _repository.GetByIdAsync(id);

			if (producto == null)
				return NotFound();

			await _repository.DeleteAsync(id);

			return NoContent();
		}
	}
}