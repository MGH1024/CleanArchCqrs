using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Queries.GetProducts;
using AutoMapper;
using Domain.Entities.Shop;

namespace Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, ProductDetailDto>();
    }
}