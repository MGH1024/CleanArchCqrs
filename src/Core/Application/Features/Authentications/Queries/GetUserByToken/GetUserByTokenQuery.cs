using Application.Responses;
using Application.Contracts.Messaging;

namespace Application.Features.Authentications.Queries.GetUserByToken;

public class GetUserByTokenQuery : IQuery<BaseQueryResponse<string>>
{
    public DTOs.User.GetUserByToken GetUserByToken { get; set; }
}