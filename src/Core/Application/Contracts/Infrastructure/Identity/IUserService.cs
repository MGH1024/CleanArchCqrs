using Application.DTOs.User;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IUserService
{
    Task<IdentityResult> CreateUser(User user);
    Task<IdentityResult> CreateUser(User user, string password);
    Task<User> GetUserById(int userId);
    Task<IdentityResult> UpdateUser(User user);
    Task<User> GetCurrentUser();
    Task<User> GetById(int userId);
    Task<bool> IsUserInRole(User user, string roleName);
    Task<User> GetByUsername(string username);
    Task<bool> IsEmailConfirmed(User user);
    Task<bool> IsPhoneNumberConfirmed(User user);
    Task<IdentityResult> DeleteUser(User user);
    Task<User> GetByEmail(string email);
    Task CreateUserRefreshToken(UserRefreshToken userRefreshToken);
    Task<User> GetUserByToken(GetUserByToken getUserByToken);
    Task DeactiveRefreshTokenRefreshToken(string refreshToken);
}