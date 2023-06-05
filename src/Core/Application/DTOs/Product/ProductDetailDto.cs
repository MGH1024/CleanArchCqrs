using Application.DTOs.Product.Base;

namespace Application.DTOs.Product;

public class ProductDetailDto : ProductDto
{
    public int Order { get; set; }
    public string CreatedDate { get; set; }
    public string CategoryTitle { get; set; }
}