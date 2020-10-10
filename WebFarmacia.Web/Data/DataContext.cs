
namespace WebFarmacia.Web.Data
{
    using System.Linq;
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

         public DbSet<Country> Countries{get;set;}
       
// modificando los decimales de los precios
 protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Medicina>()
            .Property(p=> p.Price)
            .HasColumnType("decimal(18,2)");
            
           // desabilitar el brorrado en cascada
    var cascadeFKs=modelbuilder.Model
    .GetEntityTypes()
    .SelectMany(t=> t.GetForeignKeys())
    .Where(fk=> !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (var fk in  cascadeFKs)
        {
           fk.DeleteBehavior=DeleteBehavior.Restrict;               
        }
        base.OnModelCreating(modelbuilder);

        }



    }

}