namespace WebFarmacia.Web.Controllers.API
{
    using System;  
    using System.IO; 
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using WebFarmacia.Web.Models;
    using WebFarmacia;
    
    [Route("api/[Controller]")]
    public class MedicinasController:Controller
    {
        private  readonly IProductRepository productRepository;
        //private readonly ILogger<MedicinasController> logger;

        public MedicinasController(IProductRepository productRepository) //, ILogger logger )
        { 
        this.productRepository=productRepository;
          // this.logger=logger;
        }

        [HttpGet]

         public IActionResult GetProducts()
         {
             return Ok(this.productRepository.GetAll());
         } 
    }

   
        
}
