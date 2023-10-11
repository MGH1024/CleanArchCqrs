using Domain.Entities.Security;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<OperationClaim>> GetClaimsAsync(User user,CancellationToken cancellationToken);
        Task AddAsync(User user,CancellationToken cancellationToken);
        Task<User> GetByMailAsync(string email,CancellationToken cancellationToken);
    }
}
