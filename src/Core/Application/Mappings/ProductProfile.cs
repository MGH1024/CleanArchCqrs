using AutoMapper;
using Domain.Entities.Shop;
using Application.DTOs.Product;

namespace Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProduct>().ReverseMap();
        CreateMap<Product, ProductDetail>();
    }
}