using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGestionOrdenesPanaderia.Data;
using SistemaGestionOrdenesPanaderia.Models;

namespace SistemaGestionOrdenesPanaderia.Controllers
{
	public class PedidoController : Controller
	{
		private readonly PanaderiaContext _context;

		public PedidoController(PanaderiaContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Pedidos.ToListAsync());
		}

		public IActionResult Create()
		{
			ViewBag.ClienteId = new SelectList(_context.Clientes, "Id", "Nombre");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Pedido pedido)
		{
			if (ModelState.IsValid)
			{
				_context.Add(pedido);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewBag.ClienteId = new SelectList(_context.Clientes, "Id", "Nombre", pedido.ClienteId);
			return View(pedido);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pedido = await _context.Pedidos.FindAsync(id);

			if (pedido == null)
			{
				return NotFound();
			}

			ViewBag.ClienteId = new SelectList(_context.Clientes, "Id", "Nombre", pedido.ClienteId);

			return View(pedido);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Pedido pedido)
		{
			if (id != pedido.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_context.Update(pedido);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewBag.ClienteId = new SelectList(_context.Clientes, "Id", "Nombre", pedido.ClienteId);

			return View(pedido);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pedido = await _context.Pedidos
				.FirstOrDefaultAsync(m => m.Id == id);

			if (pedido == null)
			{
				return NotFound();
			}

			return View(pedido);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pedido = await _context.Pedidos
				.FirstOrDefaultAsync(m => m.Id == id);

			if (pedido == null)
			{
				return NotFound();
			}

			return View(pedido);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var pedido = await _context.Pedidos.FindAsync(id);

			if (pedido != null)
			{
				_context.Pedidos.Remove(pedido);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}
	}
}