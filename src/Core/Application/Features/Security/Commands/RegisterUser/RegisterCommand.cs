using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Security.Commands.RegisterUser;

public class RegisterCommand : ICommand<ApiResponse>
{
    public RegisterUserDto RegisterUserDto { get; set; }
}