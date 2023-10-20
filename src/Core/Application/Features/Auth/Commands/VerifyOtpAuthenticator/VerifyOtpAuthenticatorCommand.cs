using Application.Features.Auth.Rules;
using Application.Interfaces.Security;
using Application.Interfaces.UnitOfWork;
using MediatR;
using MGH.Core.Security.Entities;
using MGH.Core.Security.Enums;

namespace Application.Features.Auth.Commands.VerifyOtpAuthenticator;

public class VerifyOtpAuthenticatorCommand : IRequest
{
    public int UserId { get; set; }
    public string ActivationCode { get; set; }

    public VerifyOtpAuthenticatorCommand()
    {
        ActivationCode = string.Empty;
    }

    public VerifyOtpAuthenticatorCommand(int userId, string activationCode)
    {
        UserId = userId;
        ActivationCode = activationCode;
    }

    public class VerifyOtpAuthenticatorCommandHandler : IRequestHandler<VerifyOtpAuthenticatorCommand>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public VerifyOtpAuthenticatorCommandHandler(
            IUnitOfWork unitOfWork,
            AuthBusinessRules authBusinessRules,
            IUserService userService,
            IAuthenticatorService authenticatorService
        )
        {
            _unitOfWork = unitOfWork;
            _authBusinessRules = authBusinessRules;
            _userService = userService;
            _authenticatorService = authenticatorService;
        }

        public async Task Handle(VerifyOtpAuthenticatorCommand request, CancellationToken cancellationToken)
        {
            OtpAuthenticator otpAuthenticator = await _unitOfWork.OtpAuthenticatorRepository.GetAsync(
                predicate: e => e.UserId == request.UserId,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.OtpAuthenticatorShouldBeExists(otpAuthenticator);

            User user = await _userService.GetAsync(predicate: u => u.Id == request.UserId, cancellationToken: cancellationToken);
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);

            otpAuthenticator!.IsVerified = true;
            user!.AuthenticatorType = AuthenticatorType.Otp;

            await _authenticatorService.VerifyAuthenticatorCode(user, request.ActivationCode);

            await _unitOfWork.OtpAuthenticatorRepository.UpdateAsync(otpAuthenticator);
            await _userService.UpdateAsync(user);
        }
    }
}
