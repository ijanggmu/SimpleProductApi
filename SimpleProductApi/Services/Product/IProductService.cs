using SimpleProductApi.Models;
using SimpleProductApi.Utilities;

namespace SimpleProductApi.Services.Product
{
    public interface IProductService
    {
        Task<PaginationResponseModel<IEnumerable<Entities.Product>>> GetProductsAsync(int page, int pageSize);
        Task<Entities.Product> GetProductByIdAsync(int id);
        Task<Entities.Product> CreateProductAsync(CreateProductRequestModel requestModel);
        Task<Entities.Product> UpdateProductAsync(int id, UpdateProductRequestModel product);
        Task<bool> DeleteProductAsync(int id);
    }
}
