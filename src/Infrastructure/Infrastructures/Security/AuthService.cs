﻿using Application.Contracts.Infrastructure.Security;
using Application.Features.Authentications.Commands.Login;
using Application.Features.Authentications.Commands.RegisterUser;
using AutoMapper;
using Domain.Entities.Security;
using Domain.Repositories;
using Infrastructures.Extensions.SecurityHelpers;

namespace Infrastructures.Security;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenHelper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthService(IUserService userService, ITokenService tokenHelper, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<User> RegisterAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(registerUserDto);
        HashingHelper.AssignPasswordToUser(registerUserDto, user);
        await _userService.Add(user, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        return user;
    }

    public async Task<bool> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByMail(loginDto.Email, cancellationToken);
        if (user is null)
            return false;
        
        var userVerify = VerifyPasswordHash(loginDto, user);
        return userVerify;
    }

    public async Task<bool> UserExistsAsync(string email, CancellationToken cancellationToken)
    {
        return await _userService.IsUserExistMail(email, cancellationToken);
    }

    public async Task<AccessTokenDto> CreateAccessTokenAsync(User user, CancellationToken cancellationToken)
    {
        var claims = await _userService.GetClaims(user, cancellationToken);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }

    private static bool VerifyPasswordHash(UserLoginDto loginDto, User user)
    {
        return HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
    }
}