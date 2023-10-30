namespace Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryDto
{
    public int Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}