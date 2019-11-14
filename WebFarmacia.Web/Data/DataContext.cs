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
        //maiando mi modelo Owner
        public DbSet<Owner> Owners { get; set; }

    }

}