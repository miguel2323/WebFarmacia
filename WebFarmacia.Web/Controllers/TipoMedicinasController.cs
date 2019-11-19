using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebFarmacia.Web.Data;
using WebFarmacia.Web.Data.Entities;

namespace WebFarmacia.Web.Controllers
{
    public class TipoMedicinasController : Controller
    {
        private readonly DataContext _context;

        public TipoMedicinasController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoMedicinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMedicinas.ToListAsync());
        }

        // GET: TipoMedicinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicinas = await _context.TipoMedicinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMedicinas == null)
            {
                return NotFound();
            }

            return View(tipoMedicinas);
        }

        // GET: TipoMedicinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMedicinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TipoMedicinas tipoMedicinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMedicinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMedicinas);
        }

        // GET: TipoMedicinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicinas = await _context.TipoMedicinas.FindAsync(id);
            if (tipoMedicinas == null)
            {
                return NotFound();
            }
            return View(tipoMedicinas);
        }

        // POST: TipoMedicinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TipoMedicinas tipoMedicinas)
        {
            if (id != tipoMedicinas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMedicinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMedicinasExists(tipoMedicinas.Id))
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
            return View(tipoMedicinas);
        }

        // GET: TipoMedicinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicinas = await _context.TipoMedicinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMedicinas == null)
            {
                return NotFound();
            }

            return View(tipoMedicinas);
        }

        // POST: TipoMedicinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMedicinas = await _context.TipoMedicinas.FindAsync(id);
            _context.TipoMedicinas.Remove(tipoMedicinas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMedicinasExists(int id)
        {
            return _context.TipoMedicinas.Any(e => e.Id == id);
        }
    }
}
