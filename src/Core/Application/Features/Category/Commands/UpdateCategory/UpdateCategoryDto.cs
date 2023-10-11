namespace Application.Features.Category.Commands.UpdateCategory;

public record UpdateCategoryDto
{
    public int Order { get; set; }
    public int Id { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}