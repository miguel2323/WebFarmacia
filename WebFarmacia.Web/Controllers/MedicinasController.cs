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
    public class MedicinasController : Controller
    {
        private readonly IRepository repository;

        public MedicinasController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Medicinas
        //muesta la lista de medicina o pinta
        public IActionResult Index()
        {
            return View(this.repository.GetMedicinas());
        }

        // GET: Medicinas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicina = this.repository.GetMedicina(id.Value);
            if (medicina == null)
            {
                return NotFound();
            }

            return View(medicina);
        }

        // GET: Medicinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicinas/Create.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Medicina medicina)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddMedicina(medicina);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicina);
        }

        // GET: Medicinas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicina =this.repository.GetMedicina(id.Value) ;
            if (medicina == null)
            {
                return NotFound();
            }
            return View(medicina);
        }

        // POST: Medicinas/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit( Medicina medicina)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateMedicina(medicina);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.MedicinaExists(medicina.Id))
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
            return View(medicina);
        }

        // GET: Medicinas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicina = this.repository.GetMedicina(id.Value );
            if (medicina == null)
            {
                return NotFound();
            }

            return View(medicina);
        }

        // POST: Medicinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicina = this.repository.GetMedicina(id);
            this.repository.RemoveMedicina(medicina);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
