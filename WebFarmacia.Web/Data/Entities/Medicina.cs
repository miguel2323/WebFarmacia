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





    }
}
