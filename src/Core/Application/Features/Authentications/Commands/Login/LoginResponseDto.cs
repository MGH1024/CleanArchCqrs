namespace Application.Features.Authentications.Commands.Login;

public record LoginResponseDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}