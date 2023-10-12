using Domain.Entities.Security;

namespace Application.Contracts.Infrastructure.Security;

public interface IUserService
{
    Task<List<Role>> GetClaims(User user, CancellationToken cancellationToken);
    Task Add(User user, CancellationToken cancellationToken);
    Task<bool> IsUserExistMail(string email, CancellationToken cancellationToken);
    Task<User> GetUserByMail(string email, CancellationToken cancellationToken);
}