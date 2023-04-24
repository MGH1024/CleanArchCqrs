namespace Application.Models.Identity;
public abstract class AuthRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
    public bool RememberMe { get; set; }
}