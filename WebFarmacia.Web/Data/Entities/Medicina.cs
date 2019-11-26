using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebFarmacia.Web.Data.Entities
{
    public class Medicina
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }

        [Display(Name ="Imagen")]
        public string ImageUrl { get; set; }


        [Display(Name = "Ultima Compra")]
        public string LastPurchase{ get; set; }



        [Display(Name = "Ultima venta")]//ultima venta
        public string LastSale { get; set; }



        [Display(Name = "Disponible")]
        public string IsAvailabe{ get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double stock { get; set; }



    }
}
