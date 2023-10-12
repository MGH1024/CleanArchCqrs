﻿using Application.Features.Security.Commands.RegisterUser;
using Domain.Entities.Security;

namespace Application.Contracts.Infrastructure.Security;

public interface ITokenService
{
    AccessTokenDto CreateToken(User user,List<Role> operationClaims);
}
