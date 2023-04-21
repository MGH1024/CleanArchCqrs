using System.Collections.ObjectModel;
using Domain.Base;

namespace Domain.Shop;

public class Category : AuditableEntity, IPageable, ICodeAble, IDropdownAble
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }


    //codeAble
    public int Code { get; set; } = 1;


    //pageable
    public int Row { get; set; }

    public int TotalCount { get; set; }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }


    //dropdownAble
    public string ListItemText
    {
        get
        {
            var strResult = Title + "-" + Code;
            return strResult;
        }
    }

    public string ListItemTextForAdmins
    {
        get
        {
            var strResult = Title + "-" + Code + "_" + IsActive.ToString();
            return strResult;
        }
    }


    //navigations
    public virtual ICollection<Product> Products { get; set; }
}