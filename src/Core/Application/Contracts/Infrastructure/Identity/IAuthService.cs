using Application.DTOs.User;
using Application.Models.Identity;
using Domain.Enums;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest login, string ipAddress, string returnUrl);
    Task<List<string>> CreateUserByRoleWithoutPassword(CreateUser createUserDto, Roles roles);
    Task<List<string>> CreateUserInUserRole(User user, string password, Roles roles);
    Task<AuthResponse> Refresh(RefreshToken refreshToken, string ipAddress);
}