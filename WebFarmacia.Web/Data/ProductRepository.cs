namespace WebFarmacia.Web.Data
{
    using Entities;

    public class ProductRepository : GenericRepository<Medicina>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}