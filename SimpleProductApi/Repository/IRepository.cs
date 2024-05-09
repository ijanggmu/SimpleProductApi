using SimpleProductApi.Utilities;
using System.Linq.Expressions;

namespace SimpleProductApi.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PaginationResponseModel<IEnumerable<TEntity>>> GetAllAsync(int page, int pageSize);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);

    }
}