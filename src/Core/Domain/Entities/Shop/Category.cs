using MGH.Domain.Abstracts;
using MGH.Domain.Concretes;

namespace Domain.Entities.Shop;

public class Category : AuditableEntity<int>, IDropdownAble,ICodeAble,IPageable,IOrderAble
{
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
            var strResult = $"{Title} - {Code}";
            return strResult;
        }
    }

    public string ListItemTextForAdmins
    {
        get
        {
            var strResult = $"{Title} - {Code}  by: {CreatedBy} + at: + {CreatedAt}";
            return strResult;
        }
    }

    //orderable
    public int Order { get; set; }
    
    
    //navigations
    public virtual ICollection<Product> Products { get; set; }
}