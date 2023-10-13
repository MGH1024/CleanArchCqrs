using MGH.Domain.Abstracts;
using MGH.Domain.Concretes;

namespace Domain.Entities.Security;

public class User :AuditableEntity<int>,IPageable,IDropdownAble
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }


    public int Row { get; set;}
    public int TotalCount { get; set;}
    public int CurrentPage { get;set; }
    public int PageSize { get; set;}
    public string ListItemText { get;set; }
    public string ListItemTextForAdmins { get;set; }
    
    
    //navigations
    public virtual ICollection<UserRole> UserRoles { get; set; }
}