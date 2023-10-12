namespace Application.Features.Security.Commands.Login;

public record UserLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}