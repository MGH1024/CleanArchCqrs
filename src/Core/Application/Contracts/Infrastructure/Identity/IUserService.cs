using Domain.Entities.Security;

namespace Application.Contracts.Infrastructure.Identity;

public interface IUserService
{
    Task<List<OperationClaim>> GetClaims(User user, CancellationToken cancellationToken);
    Task Add(User user, CancellationToken cancellationToken);
    Task<User> GetByMail(string email, CancellationToken cancellationToken);
}