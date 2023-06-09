﻿using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Messaging;
using Application.Models.Responses;
using MGH.Exceptions;

namespace Application.Features.Authentications.Queries.GetUserByToken;

public class GetUserByTokenQueryHandler : IQueryHandler<GetUserByTokenQuery, ApiResponse>
{
    private readonly IUserService _userService;

    public GetUserByTokenQueryHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<ApiResponse> Handle(GetUserByTokenQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByToken(request.GetUserByTokenDto);
        if (user is null)
            throw new BadRequestException("user not found");
        return new ApiResponse()
        {
            Data = user.UserName,
            Messages =new List<string>{ "user success returned"}
        };
    }
}