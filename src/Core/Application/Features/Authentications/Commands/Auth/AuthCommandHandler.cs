using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Messaging;
using Application.Models.Identity;
using Application.Models.Responses;

namespace Application.Features.Authentications.Commands.Auth;

public class AuthCommandHandler : ICommandHandler<AuthCommand,ApiResponse>
{
    private readonly IAuthService _authService;

    public AuthCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ApiResponse> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        return await _authService
            .Login(request.AuthRequest,request.IpAddress,request.ReturnUrl);
    }
}