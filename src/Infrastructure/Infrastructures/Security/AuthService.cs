using Application.Contracts.Infrastructure.Security;
using Application.Features.Authentications.Commands.Login;
using Application.Features.Authentications.Commands.RegisterUser;
using Domain.Entities.Security;
using Domain.Repositories;
using Infrastructures.Extensions.SecurityHelpers;

namespace Infrastructures.Security;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenHelper;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IUserService userService, ITokenService tokenHelper, IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> RegisterAsync(RegisterUserDto registerUserDto, string password,
        CancellationToken cancellationToken)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        var user = new User
        {
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LostName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true,
        };
        await _userService.Add(user, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        return user;
    }

    public async Task<User> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken)
    {
        var userCheck = await _userService.GetByMail(loginDto.Email, cancellationToken);

        if (userCheck == null)
        {
            return null;
        }

        if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userCheck.PasswordHash, userCheck.PasswordSalt))
        {
            return null;
        }

        return userCheck;
    }

    public async Task<bool> UserExistsAsync(string email, CancellationToken cancellationToken)
    {
        return await _userService.GetByMail(email, cancellationToken) == null;
    }

    public async Task<AccessTokenDto> CreateAccessTokenAsync(User user, CancellationToken cancellationToken)
    {
        var claims = await _userService.GetClaims(user, cancellationToken);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }
}