using Application.DTOs.Categories;
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Entities.Shop;

namespace Application.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CreateCategory>().ReverseMap();
        CreateMap<Category, UpdateCategory>().ReverseMap();
        CreateMap<Category, DeleteCategory>().ReverseMap();
        CreateMap<Category, CategoryDetail>().ReverseMap();
    }
}