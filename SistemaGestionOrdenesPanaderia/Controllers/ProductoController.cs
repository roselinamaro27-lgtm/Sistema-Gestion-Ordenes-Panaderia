using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionOrdenesPanaderia.Data;
using SistemaGestionOrdenesPanaderia.Models;

namespace SistemaGestionOrdenesPanaderia.Controllers
{
	public class ProductoController : Controller
	{
		private readonly PanaderiaContext _context;

		public ProductoController(PanaderiaContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Productos.ToListAsync());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Producto producto)
		{
			if (ModelState.IsValid)
			{
				_context.Add(producto);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(producto);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var producto = await _context.Productos.FindAsync(id);

			if (producto == null)
			{
				return NotFound();
			}

			return View(producto);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Producto producto)
		{
			if (id != producto.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_context.Update(producto);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(producto);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var producto = await _context.Productos
				.FirstOrDefaultAsync(m => m.Id == id);

			if (producto == null)
			{
				return NotFound();
			}

			return View(producto);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var producto = await _context.Productos
				.FirstOrDefaultAsync(m => m.Id == id);

			if (producto == null)
			{
				return NotFound();
			}

			return View(producto);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var producto = await _context.Productos.FindAsync(id);

			if (producto != null)
			{
				_context.Productos.Remove(producto);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}
	}
}