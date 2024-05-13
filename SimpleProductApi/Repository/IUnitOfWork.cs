namespace SimpleProductApi.Repository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
    }
}
