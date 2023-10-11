using MGH.Domain;

namespace Domain.Entities.Security;

public class User :Entity<int>,IPageable,IDropdownAble
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }


    public int Row { get; }
    public int TotalCount { get; }
    public int CurrentPage { get; }
    public int PageSize { get; }
    public string ListItemText { get; }
    public string ListItemTextForAdmins { get; }
}