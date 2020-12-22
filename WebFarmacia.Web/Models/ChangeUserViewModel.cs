using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFarmacia.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;

    public class ChangeUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
       
        public string LastName { get; set; }

       /* 
        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Address { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [Range(1,int.MaxValue, ErrorMessage = "You must select a city.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        [Display(Name = "State")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a state.")]
        public int StateId { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }
      */
    }
}