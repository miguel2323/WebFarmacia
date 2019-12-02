
namespace WebFarmacia.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebFarmacia.Web.Data.Entities;

    public class DataContext : IdentityDbContext<User>
    {

        //base de datos que se basa en el datacontext
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    
        public DbSet<Medicina> Medicinas { get; set; }





    }

}