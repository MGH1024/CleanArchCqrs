using System.Text;
using Application.Features.Authentications.Commands.RegisterUser;
using Domain.Entities.Security;

namespace Infrastructures.Extensions.SecurityHelpers;

public abstract class HashingHelper
{
    private static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
    {
        using var hmac=new System.Security.Cryptography.HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
    }
    
    public static void AssignPasswordToUser(RegisterUserDto registerUserDto, User user)
    {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(registerUserDto.Password, out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
    }
}