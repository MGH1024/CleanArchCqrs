using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Authentications.Queries.GetUserByToken;

public class GetUserByTokenQuery : IQuery<ApiResponse>
{
    public DTOs.User.GetUserByToken GetUserByToken { get; set; }
}