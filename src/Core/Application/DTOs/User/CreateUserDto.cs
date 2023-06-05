namespace Application.DTOs.User;

public abstract class CreateUserDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}