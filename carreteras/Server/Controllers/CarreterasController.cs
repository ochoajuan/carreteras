using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using carreteras.Server.Entidades;

namespace carreteras.Server.Controllers
{
    public class CarreterasController : Controller
    {
        private readonly carreterasContext _context;

        public CarreterasController(carreterasContext context)
        {
            _context = context;
        }

        // GET: Carreteras
        public async Task<IActionResult> Index()
        {
            var carreterasContext = _context.Carreteras.Include(c => c.Categoria);
            return View(await carreterasContext.ToListAsync());
        }

        // GET: Carreteras/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carretera = await _context.Carreteras
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carretera == null)
            {
                return NotFound();
            }

            return View(carretera);
        }

        // GET: Carreteras/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id");
            return View();
        }

        // POST: Carreteras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CategoriaId")] Carretera carretera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carretera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", carretera.CategoriaId);
            return View(carretera);
        }

        // GET: Carreteras/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carretera = await _context.Carreteras.FindAsync(id);
            if (carretera == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", carretera.CategoriaId);
            return View(carretera);
        }

        // POST: Carreteras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nombre,CategoriaId")] Carretera carretera)
        {
            if (id != carretera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carretera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreteraExists(carretera.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", carretera.CategoriaId);
            return View(carretera);
        }

        // GET: Carreteras/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carretera = await _context.Carreteras
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carretera == null)
            {
                return NotFound();
            }

            return View(carretera);
        }

        // POST: Carreteras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var carretera = await _context.Carreteras.FindAsync(id);
            _context.Carreteras.Remove(carretera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreteraExists(long id)
        {
            return _context.Carreteras.Any(e => e.Id == id);
        }
    }
}
