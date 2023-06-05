using Application.DTOs.Auth;
using Application.DTOs.User;
using Application.Models.Identity;
using Application.Models.Responses;
using Domain.Entities.Identity;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IAuthService
{
    Task<ApiResponse> Login(AuthRequestDto authRequestDto, string ipAddress, string returnUrl);
    Task<List<string>> CreateUserByRoleWithoutPassword(CreateUserDto createUserDtoDto, Roles roles);
    Task<List<string>> CreateUserInUserRole(User user, string password, Roles roles);
    Task<ApiResponse> Refresh(RefreshToken refreshToken, string ipAddress);
}