﻿using Application.DTOs.User;
using Application.Models;
using Application.Models.Identity;
using Domain.Entities.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IIdentityService
{
    Task<IEnumerable<User>> GetUsers();
    Task<IEnumerable<User>> GetUsersByShapingData();
    Task<User> GetUser(GetUserById getUserById);
    Task<User> GetUser(int userId);
    Task<bool> IsInRole(int userId, int roleId);
    Task<List<string>> UpdateUser(UpdateUser updateUser);
    Task<List<string>> DeleteUser(User user);
    Task<bool> IsEmailInUse(string email);
    Task<bool> IsUsernameInUse(string username);
    string GetCurrentUser();
}