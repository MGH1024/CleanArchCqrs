﻿using Application.Features.Authentications.Commands.RegisterUser;
using AutoMapper;
using Domain.Entities.Security;

namespace Infrastructures.Mapping;

public class SecurityProfile : Profile
{
    public SecurityProfile()
    {
        CreateMap<RegisterUserDto,User>().ReverseMap();
    }
}