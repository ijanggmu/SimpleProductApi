using SimpleProductApi.Models;
using SimpleProductApi.Repository;
using SimpleProductApi.Repository.Product;
using SimpleProductApi.Utilities;

namespace SimpleProductApi.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponseModel<IEnumerable<Entities.Product>>> GetProductsAsync(int page, int pageSize)
        {
            return await _unitOfWork.Product.GetAllAsync(page, pageSize);
        }


        public async Task<Entities.Product> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.Product.GetByIdAsync(id);
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

            return await _unitOfWork.Product.AddAsync(product);
        }

        public async Task<Entities.Product> UpdateProductAsync(int id, UpdateProductRequestModel requestModel)
        {
            var productToUpdate = await _unitOfWork.Product.GetByIdAsync(id);

            productToUpdate.Name = requestModel.Name;
            productToUpdate.Description = requestModel.Description;
            productToUpdate.Price = requestModel.Price;
            productToUpdate.Quantity = requestModel.Quantity;

            return await _unitOfWork.Product.UpdateAsync(productToUpdate);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _unitOfWork.Product.DeleteAsync(id);
        }
    }
}
