using Application.DTOs.Shop.Category.Base;

namespace Application.DTOs.Shop.Category;

public class CategoryDetail : CategoryDto
{
    public int Order { get; set; }
    public string CreatedDate { get; set; }
}