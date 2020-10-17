
namespace WebFarmacia.Web.Controllers
{
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.IO;
    using WebFarmacia.Web.Models;
    using System.Linq;

    public class MedicinasController:Controller
    {
        //private readonly IRepository repository;

        private  readonly IProductRepository productRepository;
        private readonly IUserHelper userHelper;
        public MedicinasController(IProductRepository productRepository,IUserHelper userHelper)
        {
            this.productRepository = productRepository;
            this.userHelper=userHelper;
        }                                                                                          

        // GET: Medicinas
         public IActionResult Index()
        {
            return View(this.productRepository.GetAll().OrderBy(p=>p.Name.ToUpper()));
        }
      // GET: Medicinas/Details/5
        public async Task<IActionResult>Details(int? id)
        {
            if (id == null)
            { return NotFound();
            }
            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {return NotFound();
            }
            return View(product);
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
                "wwwroot//ima//Product",
                view.ImageFile.FileName);
                    using(var stream=new FileStream(path,FileMode.Create))
                        {
                        await view.ImageFile.CopyToAsync(stream);
                        }
                        path = $"~/ima/Product/{view.ImageFile.FileName}";
                }
                var product = this.ToProduct(view, path);
                product.User=await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.productRepository.CreateAsync(product);
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
          }
          var view = this.ToMedicinaViewModel(product);
          return View(view);
        }
     private  MadicinaViewModel ToMedicinaViewModel(Medicina product)
        {
         
           return new MadicinaViewModel
               {
                Id = product.Id,
                IsAvailabe = product.IsAvailabe,
                LastPurchase = product.LastPurchase,
                ImageUrl=product.ImageUrl,
                LastSale = product.LastSale,
                Name = product.Name,
                Price = product.Price,
                stock = product.stock,
                User = product.User
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
                            "wwwroot//ima//Product",
                            view.ImageFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                         await view.ImageFile.CopyToAsync(stream);
                        }
                        path = $"~/ima/Product/{view.ImageFile.FileName}";
                    }
                    var product = this.ToProduct(view, path);
                   product.User=await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                   await this.productRepository.UpdateAsync(product);
                   //await this.productRepository.SaveAllAsync();
                 } catch (DbUpdateConcurrencyException)
                {
                    if (!await this.productRepository.ExistAsync(view.Id))
                    {
                   return NotFound();
                }
                else{
                    throw;
                }
             }
                return RedirectToAction(nameof(Index));
            }        
            return View(view);
        }
         // GET: Medicinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             var product = await this.productRepository.GetByIdAsync(id.Value );
             if (product == null)
             {
                return NotFound();
             }

             return View(product);
        }

        // POST: Medicinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           var product= await this.productRepository.GetByIdAsync(id);
             await this.productRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
