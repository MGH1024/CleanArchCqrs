using Application.Features.Authentications.Commands.Login;
using Application.Features.Authentications.Commands.RegisterUser;
using Domain.Entities.Security;

namespace Application.Contracts.Infrastructure.Identity;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterUserDto registerUserDto, string password, CancellationToken cancellationToken);
    Task<User> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken);
    Task<bool> UserExistsAsync(string email ,CancellationToken cancellationToken);
    Task<AccessTokenDto> CreateAccessTokenAsync(User user,CancellationToken cancellationToken);
}