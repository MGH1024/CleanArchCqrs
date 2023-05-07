using AutoMapper;
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.DTOs.Product.Base;
using Application.DTOs.User;
using Application.Features.Products.Commands.CreateProduct;
using Domain.Entities.Identity;
using Domain.Entities.Shop;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Category
        CreateMap<Category, CreateCategory>().ReverseMap();
        CreateMap<Category, UpdateCategory>().ReverseMap();
        CreateMap<Category, DeleteCategory>().ReverseMap();
        CreateMap<Category, CategoryDetail>().ReverseMap();


        //product
        CreateMap<Product, CreateProduct>().ReverseMap();
        CreateMap<Product, ProductDetail>();

        //Identity
        CreateMap<CreateUser, User>();
    }
}