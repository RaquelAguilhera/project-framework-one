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
    public class EntregadorsController : Controller
    {
        private readonly project_framework_oneContext _context;

        public EntregadorsController(project_framework_oneContext context)
        {
            _context = context;
        }

        // GET: Entregadors
        public async Task<IActionResult> Index()
        {
              return _context.Entregador != null ? 
                          View(await _context.Entregador.ToListAsync()) :
                          Problem("Entity set 'project_framework_oneContext.Entregador'  is null.");
        }

        // GET: Entregadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entregador == null)
            {
                return NotFound();
            }

            var entregador = await _context.Entregador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entregador == null)
            {
                return NotFound();
            }

            return View(entregador);
        }

        // GET: Entregadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entregadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Cnh,Telefone,taxa")] Entregador entregador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entregador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entregador);
        }

        // GET: Entregadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entregador == null)
            {
                return NotFound();
            }

            var entregador = await _context.Entregador.FindAsync(id);
            if (entregador == null)
            {
                return NotFound();
            }
            return View(entregador);
        }

        // POST: Entregadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Cnh,Telefone,taxa")] Entregador entregador)
        {
            if (id != entregador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entregador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregadorExists(entregador.Id))
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
            return View(entregador);
        }

        // GET: Entregadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entregador == null)
            {
                return NotFound();
            }

            var entregador = await _context.Entregador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entregador == null)
            {
                return NotFound();
            }

            return View(entregador);
        }

        // POST: Entregadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entregador == null)
            {
                return Problem("Entity set 'project_framework_oneContext.Entregador'  is null.");
            }
            var entregador = await _context.Entregador.FindAsync(id);
            if (entregador != null)
            {
                _context.Entregador.Remove(entregador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregadorExists(int id)
        {
          return (_context.Entregador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
