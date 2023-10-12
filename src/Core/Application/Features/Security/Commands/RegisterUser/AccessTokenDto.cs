namespace Application.Features.Security.Commands.RegisterUser;

public record AccessTokenDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}