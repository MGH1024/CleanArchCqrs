using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Authentications.Queries.GetUserByEmail;
public class GetUserByEmailQuery :IQuery<ApiResponse>
{
    public GetUserByEmailDto GetUserByEmailDto { get; set; }
}