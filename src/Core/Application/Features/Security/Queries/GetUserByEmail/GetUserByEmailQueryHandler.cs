using Application.Contracts.Infrastructure.Security;
using Application.Contracts.Messaging;
using Application.Models.Responses;
using Domain.Entities.Security;
using MGH.Exceptions;

namespace Application.Features.Security.Queries.GetUserByEmail;

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
        var user = await _userService.GetUserByMail(request.GetUserByEmailDto.Email, cancellationToken);
        if (user is null)
            throw new EntityNotFoundException(typeof(User));
        
        return new ApiResponse()
        {
            Data = user,
            Messages =new List<string>{ "user success returned"}
        };
    }
}