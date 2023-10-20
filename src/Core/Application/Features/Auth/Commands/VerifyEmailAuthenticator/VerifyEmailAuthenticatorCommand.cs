using Application.Features.Auth.Rules;
using Application.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Features.Auth.Commands.VerifyEmailAuthenticator;

public class VerifyEmailAuthenticatorCommand : IRequest
{
    public string ActivationKey { get; set; }

    public VerifyEmailAuthenticatorCommand()
    {
        ActivationKey = string.Empty;
    }

    public VerifyEmailAuthenticatorCommand(string activationKey)
    {
        ActivationKey = activationKey;
    }

    public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommand>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUnitOfWork _unitOfWork;

        public VerifyEmailAuthenticatorCommandHandler(
            IUnitOfWork unitOfWork,
            AuthBusinessRules authBusinessRules
        )
        {
            _unitOfWork = unitOfWork;
            _authBusinessRules = authBusinessRules;
        }

        public async Task Handle(VerifyEmailAuthenticatorCommand request, CancellationToken cancellationToken)
        {
            var emailAuthenticator = await _unitOfWork.EmailAuthenticatorRepository.GetAsync(
                predicate: e => e.ActivationKey == request.ActivationKey,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
            await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator!);

            emailAuthenticator!.ActivationKey = null;
            emailAuthenticator.IsVerified = true;
            await _unitOfWork.EmailAuthenticatorRepository.UpdateAsync(emailAuthenticator);
        }
    }
}
