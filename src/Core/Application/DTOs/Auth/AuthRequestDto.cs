namespace Application.DTOs.Auth;
public class AuthRequestDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}