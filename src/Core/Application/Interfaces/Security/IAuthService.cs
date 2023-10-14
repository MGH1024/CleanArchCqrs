using Application.Features.Security.Commands.Login;
using Application.Features.Security.Commands.RegisterUser;
using Domain.Entities.Security;

namespace Application.Interfaces.Security;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken);
    Task<User> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken);
    Task<bool> UserExistsAsync(string email ,CancellationToken cancellationToken);
    Task<AccessTokenDto> CreateAccessTokenAsync(User user,CancellationToken cancellationToken);
}