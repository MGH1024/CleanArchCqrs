namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        Task Save();
    }
}
