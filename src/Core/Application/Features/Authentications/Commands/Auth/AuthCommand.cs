using Application.Contracts.Messaging;
using Application.Models.Identity;

namespace Application.Features.Authentications.Commands.Auth;

public class AuthCommand : ICommand<AuthResponse>
{
    public AuthRequest AuthRequest { get; set; }
    public string IpAddress { get; set; }
    public string ReturnUrl { get; set; }
}