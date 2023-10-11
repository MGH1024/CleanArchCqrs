namespace Application.Features.Product.Queries.GetProducts;

public class ProductDetailDto
{
    public int Order { get; set; }
    public string CreatedDate { get; set; }
    public string CategoryTitle { get; set; }
    public int Id { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
}