using Application.Features.Authentications.Commands.RegisterUser;
using Domain.Entities.Security;

namespace Application.Contracts.Infrastructure.Security;

public interface ITokenService
{
    AccessTokenDto CreateToken(User user,List<OperationClaim> operationClaims);
}
