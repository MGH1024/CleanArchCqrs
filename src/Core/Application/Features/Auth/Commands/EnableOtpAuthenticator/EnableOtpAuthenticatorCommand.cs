using Application.Features.Auth.Rules;
using Application.Interfaces.Security;
using Application.Interfaces.UnitOfWork;
using MediatR;
using MGH.Core.Security.Entities;

namespace Application.Features.Auth.Commands.EnableOtpAuthenticator;

public class EnableOtpAuthenticatorCommand : IRequest<EnabledOtpAuthenticatorResponse>
{
    public int UserId { get; set; }

    public class EnableOtpAuthenticatorCommandHandler : IRequestHandler<EnableOtpAuthenticatorCommand, EnabledOtpAuthenticatorResponse>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public EnableOtpAuthenticatorCommandHandler(
            IUserService userService,
            IUnitOfWork unitOfWork,
            AuthBusinessRules authBusinessRules,
            IAuthenticatorService authenticatorService
        )
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _authBusinessRules = authBusinessRules;
            _authenticatorService = authenticatorService;
        }

        public async Task<EnabledOtpAuthenticatorResponse> Handle(
            EnableOtpAuthenticatorCommand request,
            CancellationToken cancellationToken
        )
        {
            User user = await _userService.GetAsync(predicate: u => u.Id == request.UserId, cancellationToken: cancellationToken);
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user!);

            OtpAuthenticator doesExistOtpAuthenticator = await _unitOfWork.OtpAuthenticatorRepository.GetAsync(
                predicate: o => o.UserId == request.UserId,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.OtpAuthenticatorThatVerifiedShouldNotBeExists(doesExistOtpAuthenticator);
            if (doesExistOtpAuthenticator is not null)
                await _unitOfWork.OtpAuthenticatorRepository.DeleteAsync(doesExistOtpAuthenticator);

            OtpAuthenticator newOtpAuthenticator = await _authenticatorService.CreateOtpAuthenticator(user!);
            OtpAuthenticator addedOtpAuthenticator = await _unitOfWork.OtpAuthenticatorRepository.AddAsync(newOtpAuthenticator);

            EnabledOtpAuthenticatorResponse enabledOtpAuthenticatorDto =
                new() { SecretKey = await _authenticatorService.ConvertSecretKeyToString(addedOtpAuthenticator.SecretKey) };
            return enabledOtpAuthenticatorDto;
        }
    }
}
