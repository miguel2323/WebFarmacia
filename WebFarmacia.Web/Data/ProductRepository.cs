namespace WebFarmacia.Web.Data
{
    using System.Linq;
    using Entities;
 using Microsoft.EntityFrameworkCore;
    public class ProductRepository :GenericRepository<Medicina>,IProductRepository
    {    private readonly DataContext context;
        public ProductRepository(DataContext context) : base(context)
        {
            
             this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Medicinas.Include(p=>p.User);
        }
    }
}