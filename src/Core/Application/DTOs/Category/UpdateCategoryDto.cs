using Application.DTOs.Category.Base;

namespace Application.DTOs.Category;

public class UpdateCategoryDto : CategoryDto
{
    public int Order { get; set; }
}