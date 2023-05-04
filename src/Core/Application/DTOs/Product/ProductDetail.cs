using Application.DTOs.Product.Base;

namespace Application.DTOs.Product;

public class ProductDetail : ProductDto
{
    public int Order { get; set; }
    public string CreatedDate { get; set; }
}