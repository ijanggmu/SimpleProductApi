using SimpleProductApi.Data;
using SimpleProductApi.Repository.Product;

namespace SimpleProductApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IProductRepository Product => _productRepository ?? new ProductRepository(_context);
    }
}
