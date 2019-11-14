using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFarmacia.Web.Data.Entities;

namespace WebFarmacia.Web.Data
{
    public class DataContext : DbContext
    {

        //base de datos que se basa en el datacontext
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        // matriculando mis tablas
        public DbSet<Owner> Owners { get; set; }

        public DbSet<Medicinas> Medicinas{ get; set; }


        public DbSet<TipoMedicinas> TipoMedicinas  { get; set; }






    }

}