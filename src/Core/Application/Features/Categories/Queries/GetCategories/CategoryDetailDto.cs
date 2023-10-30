namespace Application.Features.Category.Queries.GetCategories;

public record CategoryDetailDto
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public string CreatedDate { get; set; }
}