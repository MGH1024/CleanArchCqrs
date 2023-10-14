using Application.Interfaces.Security;
using Domain.Entities.Security;
using Domain.Repositories;

namespace Infrastructures.Security;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<Role>> GetClaims(User user, CancellationToken cancellationToken)
    {
        return await _userRepository.GetClaimsAsync(user, cancellationToken);
    }

    public async Task Add(User user, CancellationToken cancellationToken)
    {
        await _userRepository.AddAsync(user, cancellationToken);
    }

    public async Task<bool> IsUserExistMail(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByMailAsync(email, cancellationToken) is not null;
    }
    
    public async Task<User> GetUserByMail(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByMailAsync(email, cancellationToken);
    }
}