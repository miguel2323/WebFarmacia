using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFarmacia.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City:IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "City")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }


        //Clave Externa y Relacion Con la Entidad State
        public int StateId { get; set; }

        //[ForeignKey(nameof(StateId))]
        //public State State { get; set; }
    }
}
