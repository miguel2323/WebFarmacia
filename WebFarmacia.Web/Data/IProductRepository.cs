namespace WebFarmacia.Web.Data
{  
    using Entities;
    using System.Linq;
    public interface IProductRepository:IGenericRepository<Medicina>
    {
     IQueryable GetAllWithUsers();
        
    }

}