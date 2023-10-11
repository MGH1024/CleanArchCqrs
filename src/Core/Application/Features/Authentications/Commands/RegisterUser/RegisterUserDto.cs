namespace Application.Features.Authentications.Commands.RegisterUser;

public record RegisterUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LostName { get; set; }
}