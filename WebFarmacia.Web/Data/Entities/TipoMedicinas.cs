using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebFarmacia.Web.Data.Entities
{
    public class TipoMedicinas
    {
        public int Id{ get; set; }

       [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        // relacionando la tabla tipo con medicinas
        public ICollection<Medicinas> Medicinas{ get; set; }

    }
}
