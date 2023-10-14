using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Security.Commands.RegisterUser;

public class RegisterUserCommand : ICommand<ApiResponse>
{
    public RegisterUserDto RegisterUserDto { get; set; }
}