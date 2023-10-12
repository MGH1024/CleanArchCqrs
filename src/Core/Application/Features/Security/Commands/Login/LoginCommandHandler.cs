using Application.Contracts.Infrastructure.Security;
using Application.Contracts.Messaging;
using Application.Models.Responses;
using AutoMapper;

namespace Application.Features.Security.Commands.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, ApiResponse>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    public LoginCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _authService.LoginAsync(request.UserLoginDto, cancellationToken);
        var token =await _authService.CreateAccessTokenAsync(user, cancellationToken);

        return new ApiResponse
        {
            Data = token
        };
    }
}