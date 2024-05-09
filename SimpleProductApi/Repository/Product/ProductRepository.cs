using SimpleProductApi.Data;

namespace SimpleProductApi.Repository.Product
{
    public class ProductRepository : Repository<Entities.Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
