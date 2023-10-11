using Application.Features.Authentications.Commands.RegisterUser;
using Domain.Entities.Security;

namespace Application.Contracts.Infrastructure.Identity;

public interface ITokenService
{
    AccessTokenDto CreateToken(User user,List<OperationClaim> operationClaims);
}
