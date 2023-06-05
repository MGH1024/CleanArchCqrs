using Application.DTOs.Category;
using AutoMapper;
using Domain.Entities.Shop;

namespace Application.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, DeleteCategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDetailDto>().ReverseMap();
    }
}