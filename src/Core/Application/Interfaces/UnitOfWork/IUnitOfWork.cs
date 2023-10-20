using Domain.Repositories;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable,IAsyncDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }
        IEmailAuthenticatorRepository EmailAuthenticatorRepository { get; }
        IOperationClaimRepository OperationClaimRepository { get; }
        IOtpAuthenticatorRepository OtpAuthenticatorRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IUserOperationClaimRepository UserOperationClaimRepository { get; }
        Task SaveChangeAsync(CancellationToken cancellationToken);
    }
}