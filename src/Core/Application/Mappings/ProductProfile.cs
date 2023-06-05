using Application.DTOs.Product;
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