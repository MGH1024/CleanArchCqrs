namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}