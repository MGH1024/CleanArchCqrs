using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Messaging;
using Application.Exceptions;
using Application.Responses;

namespace Application.Features.Authentications.Queries.GetUserByToken;

public class GetUserByTokenQueryHandler : IQueryHandler<GetUserByTokenQuery, BaseQueryResponse<string>>
{
    private readonly IUserService _userService;

    public GetUserByTokenQueryHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<BaseQueryResponse<string>> Handle(GetUserByTokenQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByToken(request.GetUserByToken);
        if (user is null)
            throw new BadRequestException("user not found");
        return new BaseQueryResponse<string>()
        {
            Data = user.UserName,
            Success = true,
            Message = "user success returned"
        };
    }
}