using Domain.Entities.Security;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<Role>> GetClaimsAsync(User user,CancellationToken cancellationToken);
        Task AddAsync(User user,CancellationToken cancellationToken);
        Task<User> GetByMailAsync(string email,CancellationToken cancellationToken);
    }
}
