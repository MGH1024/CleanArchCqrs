using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Messaging;
using Application.Models.Responses;
using MGH.Exceptions;

namespace Application.Features.Authentications.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, ApiResponse>
{
    private readonly IUserService _userService;

    public GetUserByEmailQueryHandler(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<ApiResponse> Handle(GetUserByEmailQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userService.GetByMail(request.GetUserByEmailDto.Email, cancellationToken);
        if (user is null)
            throw new BadRequestException("user not found");
        return new ApiResponse()
        {
            Data = user,
            Messages =new List<string>{ "user success returned"}
        };
    }
}