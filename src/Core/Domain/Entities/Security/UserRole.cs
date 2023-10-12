namespace Domain.Entities.Security;

public  class UserRole
{
    public int Id { get; set; }

    //navigations
    public int UserId { get; set; }
    public virtual User User { get; set; } 
    
    public int RoleId { get; set; }
    public virtual Role Role { get; set; } 
}