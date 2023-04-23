using Application.DTOs.Category.Base;

namespace Application.DTOs.Category;

public class CategoryDetail : CategoryDto
{
    public int Order { get; set; }
    public string CreatedDate { get; set; }
}