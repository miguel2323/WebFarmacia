using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebFarmacia.Web.Data.Entities
{
    public class Medicinas
    {
        public int Id { get; set; }//codigo del proietario

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Name")]
        public string Name { get; set; }

       
        [Display(Name = "image")]
        public string imageUrl { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Codigo")]
        public int Codigo { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = " Fecha Publicacion")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]
        public DateTime Publicacion { get; set; }



        [MaxLength(20, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Precio")]
         public string Precio { get; set; }


        [Display(Name = " Fecha Publicacion")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime PublicacionLocal => Publicacion.ToLocalTime();


        // creando la relasion entre la tabla tipo y la tabla medicina
        public TipoMedicinas TipoMedicinas { get; set; }

        // Creando la relacion owner con la tabla  medicina

        public Owner Owner { get; set; }



    }
}
