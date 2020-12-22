using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFarmacia.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class State : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "State")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        [Display(Name = "# Cities")]
        public int NumberCities { get { return this.Cities == null ? 0 : this.Cities.Count; } }
    }
}
