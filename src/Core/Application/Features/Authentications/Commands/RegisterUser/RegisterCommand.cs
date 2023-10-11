using Application.Contracts.Messaging;
using Application.Features.Authentications.Commands.Login;
using Application.Models.Responses;

namespace Application.Features.Authentications.Commands.RegisterUser;

public class RegisterCommand : ICommand<ApiResponse>
{
    public RegisterUserDto RegisterUserDto { get; set; }
}