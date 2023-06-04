using Application.DTOs.Auth;
using Application.Models.Responses;
using Application.Contracts.Messaging;

namespace Application.Features.Authentications.Commands.Auth;

public class AuthCommand : ICommand<ApiResponse>
{
    public AuthRequest AuthRequest { get; set; }
    public string IpAddress { get; set; }
    public string ReturnUrl { get; set; }
}