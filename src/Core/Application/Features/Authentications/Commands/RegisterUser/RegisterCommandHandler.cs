using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Messaging;
using Application.Features.Authentications.Commands.Login;
using Application.Models.Responses;

namespace Application.Features.Authentications.Commands.RegisterUser;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, ApiResponse>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ApiResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var res = await _authService
            .RegisterAsync(request.RegisterUserDto,request.RegisterUserDto.Password, cancellationToken);
        return new ApiResponse
        {
            Data = res,
        };
    }
}