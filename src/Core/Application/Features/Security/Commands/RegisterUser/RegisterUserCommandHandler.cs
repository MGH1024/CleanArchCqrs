using Application.Contracts.Messaging;
using Application.Interfaces.Security;
using Application.Interfaces.Validation;
using Application.Models.Responses;
using AutoMapper;
using MGH.Exceptions;

namespace Application.Features.Security.Commands.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, ApiResponse>
{
    private readonly IAuthService _authService;
    private readonly IValidationService _validationService;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IAuthService authService, IValidationService validationService, IMapper mapper)
    {
        _authService = authService;
        _validationService = validationService;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _validationService.Validate<RegisterUserCommandValidator>(request);

        var isUserExist = await _authService.UserExistsAsync(request.RegisterUserDto.Email, cancellationToken);
        if (isUserExist)
            throw new DuplicateException("Email", typeof(RegisterUserDto));

        var user = await _authService.RegisterAsync(request.RegisterUserDto, cancellationToken);
        return new ApiResponse(_mapper.Map<GetUserDto>(user),"user created.");
    }
}