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
    public class EstoquesController : Controller
    {
        private readonly project_framework_oneContext _context;

        public EstoquesController(project_framework_oneContext context)
        {
            _context = context;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            var project_framework_oneContext = _context.Estoque.Include(e => e.Fornecedor).Include(e => e.Ingrediente);
            return View(await project_framework_oneContext.ToListAsync());
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
                .Include(e => e.Fornecedor)
                .Include(e => e.Ingrediente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoques/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "NomeFantasia");
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Nome");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FornecedorId,IngredienteId")] Estoque estoque)
        {
            //if (ModelState.IsValid)
            //{
                //_context.Add()
            //}
            //ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "NomeFantasia", estoque.FornecedorId);
            //ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Nome", estoque.IngredienteId);
            //return View(estoque);
            _context.Add(estoque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "NameFantasia", estoque.FornecedorId);
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Nome", estoque.IngredienteId);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FornecedorId,IngredienteId")] Estoque estoque)
        {
            if (id != estoque.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //Try Catch
            //}
            //ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "Id", estoque.FornecedorId);
            //ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Id", estoque.IngredienteId);
            //return View(estoque);
            try
            {
                _context.Update(estoque);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(estoque.Id))
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

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
                .Include(e => e.Fornecedor)
                .Include(e => e.Ingrediente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estoque == null)
            {
                return Problem("Entity set 'project_framework_oneContext.Estoque'  is null.");
            }
            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque != null)
            {
                _context.Estoque.Remove(estoque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
          return (_context.Estoque?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
