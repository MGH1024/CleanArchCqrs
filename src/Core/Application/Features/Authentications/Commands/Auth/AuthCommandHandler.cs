using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Messaging;
using Application.Models.Identity;

namespace Application.Features.Authentications.Commands.Auth;

public class AuthCommandHandler : ICommandHandler<AuthCommand,AuthResponse>
{
    private readonly IAuthService _authService;

    public AuthCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<AuthResponse> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        return await _authService
            .Login(request.AuthRequest,request.IpAddress,request.ReturnUrl);
    }
}