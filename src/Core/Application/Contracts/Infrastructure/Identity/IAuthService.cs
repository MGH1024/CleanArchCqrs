﻿using Application.DTOs.User;
using Application.Models.Identity;
using Domain.Entities.Identity;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest authRequest, string ipAddress, string returnUrl);
    Task<List<string>> CreateUserByRoleWithoutPassword(CreateUser createUserDto, Roles roles);
    Task<List<string>> CreateUserInUserRole(User user, string password, Roles roles);
    Task<AuthResponse> Refresh(RefreshToken refreshToken, string ipAddress);
}