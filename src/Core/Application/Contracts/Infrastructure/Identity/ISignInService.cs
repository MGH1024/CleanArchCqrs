using System.Security.Claims;
using Application.DTOs.Auth;
using Application.DTOs.User;
using Application.Models.Identity;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface ISignInService
{
    Task SignOut();
    Task<SignInResult> SignIn(User user, AuthRequestDto login);
    Task<IEnumerable<Claim>> GetClaimByUser(User user);
}