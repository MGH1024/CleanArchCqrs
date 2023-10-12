namespace Domain.Entities.Security;

public class Role
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    
    //navigations
    public virtual ICollection<Permission> Permissions { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}