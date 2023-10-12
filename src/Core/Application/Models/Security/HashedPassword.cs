namespace Application.Models.Security;

public class HashedPassword
{
    public byte[]  PasswordHash { get; set; }
    public byte[]  PasswordSalt { get; set; }
}