﻿using NSubstitute;
using Application.Contracts.Infrastructure.Identity;

namespace TestProject.Base.Fixtures;

public class UserServiceFixture
{
    public readonly IUserService UserService;

    public UserServiceFixture()
    {
        UserService = Substitute.For<IUserService>();
    }
}