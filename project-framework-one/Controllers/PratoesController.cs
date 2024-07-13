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
    public class PratoesController : Controller
    {
        private readonly project_framework_oneContext _context;

        public PratoesController(project_framework_oneContext context)
        {
            _context = context;
        }

        // GET: Pratoes
        public async Task<IActionResult> Index()
        {
              return _context.Prato != null ? 
                          View(await _context.Prato.ToListAsync()) :
                          Problem("Entity set 'project_framework_oneContext.Prato'  is null.");
        }

        // GET: Pratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // GET: Pratoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pratoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Categoria,Qtde,Peso,Preco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prato);
        }

        // GET: Pratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato.FindAsync(id);
            if (prato == null)
            {
                return NotFound();
            }
            return View(prato);
        }

        // POST: Pratoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Categoria,Qtde,Peso,Preco")] Prato prato)
        {
            if (id != prato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PratoExists(prato.Id))
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
            return View(prato);
        }

        // GET: Pratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // POST: Pratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prato == null)
            {
                return Problem("Entity set 'project_framework_oneContext.Prato'  is null.");
            }
            var prato = await _context.Prato.FindAsync(id);
            if (prato != null)
            {
                _context.Prato.Remove(prato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PratoExists(int id)
        {
          return (_context.Prato?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
