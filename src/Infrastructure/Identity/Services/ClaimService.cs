using System.Security.Claims;
using Application.Contracts.Infrastructure.Identity;
using Application.DTOs.User;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services;

public class ClaimService : IClaimService
{
    private readonly UserManager<User> _userManager;

    public ClaimService(UserManager<User> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<IdentityResult> AddClaimToUser(User user)
    {
        var claims = new List<Claim>
                        {
                            new Claim("userName",user.UserName),
                            new Claim("email",user.Email),
                            new Claim("givenName",user.Firstname),
                            new Claim("surName",user.Lastname)
                        };
        return await _userManager.AddClaimsAsync(user, claims);
    }

    public async Task<IdentityResult> RemoveClaimsByUser(User user)
    {
        var oldClaims = new List<Claim>
                    {
                        new Claim("email",user.Email),
                        new Claim("givenName",user.Firstname),
                        new Claim("surName",user.Lastname)
                    };
        return await _userManager.RemoveClaimsAsync(user, oldClaims);
    }

    public async Task<IdentityResult> AssignClaimsToUser(User user, UpdateUserDto updateUserDto)
    {
        var newClaims = new List<Claim>
                                {
                                    new Claim("email",updateUserDto.Email),
                                    new Claim("givenName",updateUserDto.Firstname),
                                    new Claim("surName",updateUserDto.Lastname)
                                };
        return await _userManager.AddClaimsAsync(user, newClaims);
    }
}

