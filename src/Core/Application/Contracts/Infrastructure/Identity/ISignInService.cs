using System.Security.Claims;
using Application.DTOs.User;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface ISignInService
{
    Task SignOut();
    Task<SignInResult> SignIn(User user, Login login);
    Task<IEnumerable<Claim>> GetClaimByUser(User user);
}