using Application.DTOs.User;
using Application.Models;
using Domain.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IIdentityService
{
    Task<IEnumerable<User>> GetUsers(GetParameter getParameter);
    Task<IEnumerable<User>> GetUsersByShapingData(GetParameter getParameter);
    Task<User> GetUser(GetUserById getUserById);
    Task<User> GetUser(int userId);
    Task<List<string>> CreateUserSimple(CreateUserDto createUserDto);
    Task<List<string>> CreateUser(User user, string password);
    Task<bool> IsInRole(int userId, int roleId);
    Task<List<string>> UpdateUser(UpdateUser updateUser);
    Task<List<string>> DeleteUser(User user);
    Task<LoginResult> Login(Login login, string ipAddress, string returnUrl);
    Task<bool> IsEmailInUse(string email);
    Task<bool> IsUsernameInUse(string username);
    string GetCurrentUser();
    Task<LoginResult> Refresh(RefreshToken refreshToken, string ipAddress);
}