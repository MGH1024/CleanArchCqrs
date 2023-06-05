using Application.DTOs.User;
using Domain;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IClaimService
{
    Task<IdentityResult> AddClaimToUser(User user);
    Task<IdentityResult> RemoveClaimsByUser(User user);
    Task<IdentityResult> AssignClaimsToUser(User user, UpdateUserDto updateUserDto);
}