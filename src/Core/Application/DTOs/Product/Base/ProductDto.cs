using Application.DTOs.Base;

namespace Application.DTOs.Product.Base
{
    public class ProductDto : BaseDto
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string CategoryTitle { get; set; }
    }
}