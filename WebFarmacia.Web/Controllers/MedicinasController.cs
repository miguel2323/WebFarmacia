
namespace WebFarmacia.Web.Controllers
{using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Models;
using Helpers;
    public class MedicinasController : Controller
    {
        private readonly IRepository repository;
        private readonly IUserHelper userHelper;
        public MedicinasController(IRepository repository,IUserHelper userHelper)
        {
            this.repository = repository;
            this.userHelper=userHelper;
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
        public async Task<IActionResult> Create(MadicinaViewModel view)
        {
            if (ModelState.IsValid)
            {
                
                var path = string.Empty;

               if(view.ImageFile !=null &&view.ImageFile.Length>0)
                {

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(), 
                        "wwwroot//ima//Product",view.ImageFile.FileName);

                    using(var stream=new FileStream(path,FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"/ima/Product/{view.ImageFile.FileName}";
                }
                 
                
                var product = this.ToProduct(view, path);
                
                product.User=await this.userHelper.GetUserByEmailAsync("miguelrojas8143@gmail.com");
                this.repository.AddMedicina(product);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Medicina ToProduct(MadicinaViewModel view, string path)
        {
            return new Medicina
            {
                Id = view.Id,
                ImageUrl = path,
                IsAvailabe = view.IsAvailabe,
               LastPurchase=view.LastPurchase,
               LastSale= view.LastSale,
               Name =view.Name,
               Price= view.Price,
               stock= view.stock,
               User=view.User
            
            };
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

            var view = this.ToMedicinaViewModel(medicina);
            return View(view);
        }

        private MadicinaViewModel ToMedicinaViewModel(Medicina medicina)
        {
           return new  MadicinaViewModel

                {
                Id = medicina.Id,
              
               IsAvailabe = medicina.IsAvailabe,
               LastPurchase = medicina.LastPurchase,
               ImageUrl=medicina.ImageUrl,
               LastSale = medicina.LastSale,
               Name = medicina.Name,
               Price = medicina.Price,
               stock = medicina.stock,
               User = medicina.User


            };
        }

        // POST: Medicinas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit(MadicinaViewModel view)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;
                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\ima\\Product",
                            view.ImageFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"/ima/Product/{view.ImageFile.FileName}";
                    }



                    var medicina = this.ToProduct(view, path);

                    this.repository.UpdateMedicina(medicina);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.MedicinaExists(view.Id))
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
            return View(view);
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
