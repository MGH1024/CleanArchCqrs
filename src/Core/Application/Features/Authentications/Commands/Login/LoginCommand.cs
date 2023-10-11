using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Authentications.Commands.Login;

public class LoginCommand : ICommand<ApiResponse>
{
    public UserLoginDto UserLoginDto { get; set; }
}