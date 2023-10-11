using Application.DTOs.User;
using AutoMapper;
using Domain.Entities.Security;

namespace Application.Mappings;

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}