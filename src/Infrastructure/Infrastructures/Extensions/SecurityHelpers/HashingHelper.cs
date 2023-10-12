using System.Text;
using Application.Features.Security.Commands.RegisterUser;
using Application.Models.Security;
using Domain.Entities.Security;

namespace Infrastructures.Extensions.SecurityHelpers;

public abstract class HashingHelper
{
    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
    }

    public static void AssignPasswordToUser(RegisterUserDto registerUserDto, User user)
    {
        var hashedPassword = GetHashedPasswordByPassword(registerUserDto.Password);
        user.PasswordHash = hashedPassword.PasswordHash;
        user.PasswordSalt = hashedPassword.PasswordSalt;
    }

    public static HashedPassword GetHashedPasswordByPassword(string password)
    {
        var hmac = new System.Security.Cryptography.HMACSHA512();
        return new HashedPassword
        {
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key,
        };
    }
}