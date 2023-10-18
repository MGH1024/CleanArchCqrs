using MGH.Core.Application.Responses;
using MGH.Core.Security.Enums;
using MGH.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Login;

public class LoggedResponse : IResponse
{
    public AccessToken AccessToken { get; set; }
    public MGH.Core.Security.Entities.RefreshToken RefreshToken { get; set; }
    public AuthenticatorType RequiredAuthenticatorType { get; set; }

    public LoggedHttpResponse ToHttpResponse() =>
        new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType };

    public class LoggedHttpResponse
    {
        public AccessToken AccessToken { get; set; }
        public AuthenticatorType RequiredAuthenticatorType { get; set; }
    }
}
