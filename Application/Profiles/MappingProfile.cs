﻿using AutoMapper;
using Domain.Shop;
using Application.DTOs.Category;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CreateCategory>().ReverseMap();
        CreateMap<Category, UpdateCategory>().ReverseMap();
        CreateMap<Category, DeleteCategory>().ReverseMap();
        CreateMap<Category, CategoryDetail>().ReverseMap();
    }
}