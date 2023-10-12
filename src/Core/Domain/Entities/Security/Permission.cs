namespace Domain.Entities.Security;

public class Permission
{
    public int Id { get; set; }

    public string Title { get; set; }

    
    //navigations
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}