using Application.DTOs.Category.Base;

namespace Application.DTOs.Category;

public class UpdateCategory : CategoryDto
{
    public int Order { get; set; }
}