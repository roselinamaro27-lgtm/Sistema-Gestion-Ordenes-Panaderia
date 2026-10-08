using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGestionOrdenesPanaderia.Data;
using SistemaGestionOrdenesPanaderia.Models;

namespace SistemaGestionOrdenesPanaderia.Controllers
{
	public class DetallePedidoController : Controller
	{
		private readonly PanaderiaContext _context;

		public DetallePedidoController(PanaderiaContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.DetallesPedido.ToListAsync());
		}

		public IActionResult Create()
		{
			ViewBag.PedidoId = new SelectList(_context.Pedidos, "Id", "Id");
			ViewBag.ProductoId = new SelectList(_context.Productos, "Id", "Nombre");

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DetallePedido detallePedido)
		{
			if (ModelState.IsValid)
			{
				_context.Add(detallePedido);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewBag.PedidoId = new SelectList(_context.Pedidos, "Id", "Id", detallePedido.PedidoId);
			ViewBag.ProductoId = new SelectList(_context.Productos, "Id", "Nombre", detallePedido.ProductoId);

			return View(detallePedido);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var detallePedido = await _context.DetallesPedido.FindAsync(id);

			if (detallePedido == null)
			{
				return NotFound();
			}

			ViewBag.PedidoId = new SelectList(_context.Pedidos, "Id", "Id", detallePedido.PedidoId);
			ViewBag.ProductoId = new SelectList(_context.Productos, "Id", "Nombre", detallePedido.ProductoId);

			return View(detallePedido);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, DetallePedido detallePedido)
		{
			if (id != detallePedido.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_context.Update(detallePedido);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewBag.PedidoId = new SelectList(_context.Pedidos, "Id", "Id", detallePedido.PedidoId);
			ViewBag.ProductoId = new SelectList(_context.Productos, "Id", "Nombre", detallePedido.ProductoId);

			return View(detallePedido);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var detallePedido = await _context.DetallesPedido
				.FirstOrDefaultAsync(m => m.Id == id);

			if (detallePedido == null)
			{
				return NotFound();
			}

			return View(detallePedido);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var detallePedido = await _context.DetallesPedido
				.FirstOrDefaultAsync(m => m.Id == id);

			if (detallePedido == null)
			{
				return NotFound();
			}

			return View(detallePedido);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var detallePedido = await _context.DetallesPedido.FindAsync(id);

			if (detallePedido != null)
			{
				_context.DetallesPedido.Remove(detallePedido);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}
	}
}