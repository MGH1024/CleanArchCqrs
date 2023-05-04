using AutoMapper;
using Domain.Shop;
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.DTOs.Product.Base;
using Application.DTOs.User;
using Application.Features.Products.Commands.CreateProduct;
using Domain.Identity;

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
        CreateMap<Product, ProductDetail>()
            .ForMember(dest => dest.CategoryTitle,
                a
                    => a.MapFrom(src => src.Category.Title));

        //Identity
        CreateMap<CreateUser, User>();
    }
}