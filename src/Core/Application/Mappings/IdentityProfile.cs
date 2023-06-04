using AutoMapper;
using Application.DTOs.User;
using Domain.Entities.Identity;

namespace Application.Mapping;

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<CreateUser, User>();
    }
}