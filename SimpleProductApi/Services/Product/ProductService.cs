using SimpleProductApi.Models;
using SimpleProductApi.Repository;
using SimpleProductApi.Repository.Product;

namespace SimpleProductApi.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Entities.Product>> GetProductsAsync(int page, int pageSize)
        {
            return await _productRepository.GetAllAsync(page, pageSize);
        }


        public async Task<Entities.Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Entities.Product> CreateProductAsync(CreateProductRequestModel requestModel)
        {
            var product = new Entities.Product
            {
                Name = requestModel.Name,
                Description = requestModel.Description,
                Price = requestModel.Price,
                Quantity = requestModel.Quantity,
            };

            return await _productRepository.AddAsync(product);
        }

        public async Task<Entities.Product> UpdateProductAsync(int id, UpdateProductRequestModel requestModel)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(id);

            productToUpdate.Name = requestModel.Name;
            productToUpdate.Description = requestModel.Description;
            productToUpdate.Price = requestModel.Price;
            productToUpdate.Quantity = requestModel.Quantity;

            return await _productRepository.UpdateAsync(productToUpdate);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
