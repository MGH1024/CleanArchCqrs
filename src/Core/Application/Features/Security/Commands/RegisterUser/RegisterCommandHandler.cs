using Application.Contracts.Infrastructure.Security;
using Application.Contracts.Messaging;
using Application.Models.Responses;
using MGH.Exceptions;

namespace Application.Features.Security.Commands.RegisterUser;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, ApiResponse>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ApiResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var isUserExist = await _authService.UserExistsAsync(request.RegisterUserDto.Email, cancellationToken);
        if (isUserExist)
            throw new DuplicateException("Email", typeof(RegisterUserDto));
        
        var user = await _authService.RegisterAsync(request.RegisterUserDto, cancellationToken);
        return new ApiResponse
        {
            Data = user,
        };
    }
}