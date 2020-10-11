using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebFarmacia.Web.Data.Entities
{
    public class Medicina:IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field{0} oly can contain {1}  characters length. ")]
        [Required]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }

        [Display(Name ="Imagen")]
        public string ImageUrl { get; set; }

        [Display(Name = "Ultima Compra")]
        public DateTime? LastPurchase{ get; set; }

        [Display(Name = "Ultima venta")]//ultima venta
        public DateTime? LastSale { get; set; }

        [Display(Name = "Disponible?")]
        public bool IsAvailabe{ get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double stock { get; set; }
      public User User { get; set; }

       [Display(Name ="Imagen")]
        public string ImageFullPath { get;}

    }
}
