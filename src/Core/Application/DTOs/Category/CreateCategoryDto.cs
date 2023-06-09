using Application.DTOs.Category.Base;

namespace Application.DTOs.Category;

public class CreateCategoryDto 
{
    public int Code { get; set; }
    public string Title  { get; set; }
    public string Description { get; set; }
}