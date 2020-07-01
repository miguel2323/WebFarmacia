


namespace WebFarmacia.Web.Models
{using System.ComponentModel.DataAnnotations;
  using WebFarmacia.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;
    public class MadicinaViewModel : Medicina
    {
        [Display(Name="Imege")]
        public IFormFile ImageFile { get; set; }

    }
}
