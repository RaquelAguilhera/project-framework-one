using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_framework_one.Data;
using project_framework_one.Models;

namespace project_framework_one.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly project_framework_oneContext _context;

        public PedidoesController(project_framework_oneContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var project_framework_oneContext = _context.Pedido.Include(p => p.Cliente).Include(p => p.Entregador).Include(p => p.Prato);
            return View(await project_framework_oneContext.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Entregador)
                .Include(p => p.Prato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["EntregadorId"] = new SelectList(_context.Entregador, "Id", "Nome");
            ViewData["PratoId"] = new SelectList(_context.Prato, "Id", "Nome");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,PratoId,EntregadorId")] Pedido pedido)
        {
            //if (ModelState.IsValid)
            //{
                //_context
            //}
            //ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", pedido.ClienteId);
            //ViewData["EntregadorId"] = new SelectList(_context.Entregador, "Id", "Id", pedido.EntregadorId);
            //ViewData["PratoId"] = new SelectList(_context.Prato, "Id", "Id", pedido.PratoId);
            //return View(pedido);
            _context.Add(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", pedido.ClienteId);
            ViewData["EntregadorId"] = new SelectList(_context.Entregador, "Id", "Nome", pedido.EntregadorId);
            ViewData["PratoId"] = new SelectList(_context.Prato, "Id", "Nome", pedido.PratoId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,PratoId,EntregadorId")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                //Try Catch
            //}
            //ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", pedido.ClienteId);
            //ViewData["EntregadorId"] = new SelectList(_context.Entregador, "Id", "Id", pedido.EntregadorId);
            //ViewData["PratoId"] = new SelectList(_context.Prato, "Id", "Id", pedido.PratoId);
            //return View(pedido);
            try
            {
                _context.Update(pedido);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(pedido.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Entregador)
                .Include(p => p.Prato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedido == null)
            {
                return Problem("Entity set 'project_framework_oneContext.Pedido'  is null.");
            }
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedido.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return (_context.Pedido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
