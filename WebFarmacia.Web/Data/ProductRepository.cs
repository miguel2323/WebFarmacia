namespace WebFarmacia.Web.Data
{
    using Entities;

    public class ProductRepository :GenericRepository<Medicina>,IProductRepository
    {private readonly DataContext context;
        public ProductRepository(DataContext context) : base(context)
        {
            
             this.context = context;
        }
    }
}