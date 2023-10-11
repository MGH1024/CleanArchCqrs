namespace Application.Features.Category.Commands.CreateCategory;

public record CreateCategoryDto
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}