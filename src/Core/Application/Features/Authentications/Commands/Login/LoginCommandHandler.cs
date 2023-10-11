using Application.Contracts.Infrastructure.Security;
using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Authentications.Commands.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, ApiResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ApiResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _authService
            .LoginAsync(request.UserLoginDto, cancellationToken);

        return new ApiResponse
        {
            Data = user
        };
    }
}