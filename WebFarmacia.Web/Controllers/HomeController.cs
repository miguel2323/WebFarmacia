using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFarmacia.Web.Models;
using WebFarmacia.Web.Data;
using WebFarmacia.Web.Data.Entities;

namespace WebFarmacia.Web.Controllers
{
    public class HomeController : Controller
    {


        private readonly IProductRepository repository;

        public HomeController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(this.repository.GetAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
