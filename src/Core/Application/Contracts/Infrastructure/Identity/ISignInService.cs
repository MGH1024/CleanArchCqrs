using System.Security.Claims;
using Application.DTOs.User;
using Application.Models.Identity;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface ISignInService
{
    Task SignOut();
    Task<SignInResult> SignIn(User user, AuthRequest login);
    Task<IEnumerable<Claim>> GetClaimByUser(User user);
}