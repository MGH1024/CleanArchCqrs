namespace Application.Features.Product.Commands.UpdateProduct;

public record UpdateProductDto
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
}