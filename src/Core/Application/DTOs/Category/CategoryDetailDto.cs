using Application.DTOs.Category.Base;

namespace Application.DTOs.Category;

public class CategoryDetailDto : CategoryDto
{
    public int Order { get; set; }
    public string CreatedDate { get; set; }
}