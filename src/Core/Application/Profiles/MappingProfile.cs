using AutoMapper;
using Domain.Shop;
using Application.DTOs.Category;
using Application.DTOs.User;
using Domain.Identity;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CreateCategory>().ReverseMap();
        CreateMap<Category, UpdateCategory>().ReverseMap();
        CreateMap<Category, DeleteCategory>().ReverseMap();
        CreateMap<Category, CategoryDetail>().ReverseMap();
        
        
        //Identity
        CreateMap<CreateUser, User>();
    }
}