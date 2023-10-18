﻿using MGH.Core.Domain.Abstracts;
using MGH.Core.Domain.Concretes;

namespace Domain.Entities.Shop;

public class Product : AuditableEntity<int>,IDropdownAble,ICodeAble,IPageable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public  int Quantity { get; set; }

    
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
    
    
    //navigations
    public virtual int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}