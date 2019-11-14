using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFarmacia.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }//codigo del proietario
        [Required(ErrorMessage ="The field {0} is mandatory.")]
        [MaxLength(30, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        public string Document { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set;}
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Last Name")]
        public string  LastName { get; set; }
        [MaxLength(20,ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(20, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        [Display(Name = "Cell Phone")]

        public string CellPhone  { get; set; }
        [MaxLength(100, ErrorMessage = "The {0} field  can not have more than {1} charactrs. ")]
        public string  Address{ get; set; }

        //propiedades de lectura nombre y apellidos
        [Display(Name = "Owner")]
        public string FullName => $"{FirstName}{LastName}";
        [Display(Name = "Owner")]
        public string FullNameWithDocument => $"{FirstName}{LastName} - {Document}";



        //relacionando la tabla owner con la tabla medicinas

        public ICollection<Medicinas> Medicinas { get; set; }


    }
}
