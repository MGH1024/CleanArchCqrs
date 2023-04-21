using Application.DTOs.Shop.Category.Base;

namespace Application.DTOs.Shop.Category;

public class UpdateCategory : CategoryDto
{
    public int Order { get; set; }
}