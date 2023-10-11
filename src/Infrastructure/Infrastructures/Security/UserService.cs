using Application.Contracts.Infrastructure.Identity;
using Domain.Entities.Security;
using Domain.Repositories;

namespace Infrastructures.Identity;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<OperationClaim>> GetClaims(User user, CancellationToken cancellationToken)
    {
        return await _userRepository.GetClaimsAsync(user, cancellationToken);
    }

    public async Task Add(User user, CancellationToken cancellationToken)
    {
        await _userRepository.AddAsync(user, cancellationToken);
    }

    public async Task<User> GetByMail(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByMailAsync(email, cancellationToken);
    }
}