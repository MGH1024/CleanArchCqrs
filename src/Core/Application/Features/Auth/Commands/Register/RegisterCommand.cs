using Application.Features.Auth.Rules;
using Application.Interfaces.Security;
using Application.Interfaces.UnitOfWork;
using MediatR;
using MGH.Core.Application.DTOs.Security;
using MGH.Core.Security.Entities;
using MGH.Core.Security.Hashing;
using MGH.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

                HashingHelper.CreatePasswordHash(
                    request.UserForRegisterDto.Password,
                    passwordHash: out byte[] passwordHash,
                    passwordSalt: out byte[] passwordSalt
                );
                User newUser =
                    new()
                    {
                        Email = request.UserForRegisterDto.Email,
                        FirstName = request.UserForRegisterDto.FirstName,
                        LastName = request.UserForRegisterDto.LastName,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                    };
                User createdUser = await _unitOfWork.UserRepository.AddAsync(newUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

                MGH.Core.Security.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                MGH.Core.Security.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
                return registeredResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
