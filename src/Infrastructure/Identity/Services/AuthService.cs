﻿using AutoMapper;
using System.Text;
using Domain.Enums;
using Application.DTOs.User;
using Application.Models.Identity;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Application.Contracts.Infrastructure;
using Application.Contracts.Infrastructure.Identity;
using Application.DTOs.Auth;
using Application.Models.Responses;
using Domain.Entities.Identity;
using Domain.Repositories;
using MGH.Exceptions;

namespace Identity.Services;

public class AuthService : IAuthService
{
    private readonly Auth _auth;
    private readonly IMapper _mapper;
    private readonly IDateTime _dateTime;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;
    private readonly IClaimService _claimService;
    private readonly UserManager<User> _userManager;
    private readonly ISignInService _signInService;
    private readonly IUserRepository _userRepository;

    public AuthService(UserManager<User> userManager, IMapper mapper,
        IRoleService roleService, IClaimService claimService,
        IUserService userService, ISignInService signInService,
        IOptions<Auth> options, IDateTime dateTime, IUserRepository userRepository)
    {
        _auth = options.Value;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _claimService = claimService ?? throw new ArgumentNullException(nameof(claimService));
        _signInService = signInService ?? throw new ArgumentNullException(nameof(signInService));
    }

    public async Task<List<string>> CreateUserByRoleWithoutPassword(CreateUserDto createUserDtoDto, Roles roles)
    {
        var user = _mapper.Map<User>(createUserDtoDto);
        var strResult = new List<string>();
        var userResult = await CreateUserWithoutPassword(user);
        var roleResult = await _roleService.AddRoleToUser(user, (int)roles);
        var claimResult = await _claimService.AddClaimToUser(user);
        if (userResult.Succeeded && roleResult.Succeeded && claimResult.Succeeded)
        {
            return strResult;
        }
        else
        {
            strResult.AddRange(GetIdentityError(userResult.Errors));
            strResult.AddRange(GetIdentityError(roleResult.Errors));
            strResult.AddRange(GetIdentityError(claimResult.Errors));
            return strResult;
        }
    }

    public async Task<List<string>> CreateUserInUserRole(User user, string password, Roles roles)
    {
        var strResult = new List<string>();
        var userResult = await CreateUserByPassword(user, password);
        var roleResult = await _roleService.AddRoleToUser(user, (int)roles);
        var claimResult = await _claimService.AddClaimToUser(user);
        if (userResult.Succeeded && roleResult.Succeeded && claimResult.Succeeded)
        {
            return strResult;
        }
        else
        {
            strResult.AddRange(GetIdentityError(userResult.Errors));
            strResult.AddRange(GetIdentityError(roleResult.Errors));
            strResult.AddRange(GetIdentityError(claimResult.Errors));
            return strResult;
        }
    }

    [Obsolete("Obsolete")]
    public async Task<ApiResponse> Login(AuthRequestDto authRequestDto, string ipAddress, string returnUrl)
    {
        var user = await _userService.GetByUsername(authRequestDto.UserName);

        //2do if user signed in redirect to returnUrl
        var errors = new List<string>();

        if (user != null)
        {
            await _signInService.SignOut();
            var signinResult = await _signInService.SignIn(user, authRequestDto);

            if (signinResult.IsNotAllowed)
            {
                if (!await _userService.IsEmailConfirmed(user))
                    errors.Add("email not confirmed");


                if (!await _userService.IsPhoneNumberConfirmed(user))
                    errors.Add("Tell not confirmed");

                return new ApiResponse
                {
                    Messages = errors
                };
            }

            if (signinResult.Succeeded)
            {
                //token
                var token = await GenerateTokenByUser(user);
                var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
                var tokenValidDate = _dateTime
                    .IranNow
                    .AddMinutes(_auth.TokenAddedExpirationDateValue);

                //refreshToken
                var refreshToken = GenerateRefreshToken();
                var refreshTokenValidDate = _dateTime
                    .IranNow
                    .AddMinutes(_auth.RefreshTokenAddedExpirationDateValue);
                await _userService.CreateUserRefreshToken(new UserRefreshToken
                {
                    CreatedDate = _dateTime.IranNow,
                    ExpirationDate = refreshTokenValidDate,
                    IpAddress = ipAddress,
                    IsInvalidated = false,
                    RefreshToken = refreshToken,
                    Token = tokenAsString,
                    UserId = user.Id
                });

                var authResponse = new AuthResponse
                {
                    ReturnUrl = returnUrl,
                    Token = tokenAsString,
                    RefreshToken = refreshToken,
                    TokenValidDate = tokenValidDate,
                };
                return new ApiResponse(data: authResponse,
                    messages: new List<string> { "successfully login!" });
            }

            if (signinResult.RequiresTwoFactor)
            {
                //2Do
            }

            if (signinResult.IsLockedOut)
            {
                return new ApiResponse
                {
                    Messages = new List<string> { "your account is lock" },
                };
            }
        }

        return new ApiResponse
        {
            Messages = new List<string> { "user not found" },
        };
    }

    [Obsolete("Obsolete")]
    public async Task<ApiResponse> Refresh(RefreshToken refreshToken, string ipAddress)
    {
        if (refreshToken is null)
            throw new BadRequestException("");

        var user = await _userService.GetUserByToken(new GetUserByTokenDto { Token = refreshToken.Token });
        if (user is null)
            throw new BadRequestException("");


        var userRefreshToken =
            _userRepository.GetUserRefreshTokenByUserAndOldToken(user, refreshToken.Token, refreshToken.RefToken);
        if (userRefreshToken is null)
            throw new BadRequestException("");


        var newToken = new JwtSecurityTokenHandler().WriteToken(await GenerateTokenByUser(user));
        var newTokenValidDate = _dateTime
            .IranNow
            .AddMinutes(_auth.TokenAddedExpirationDateValue);


        if (userRefreshToken.ExpirationDate < _dateTime.IranNow)
        {
            var newRefreshToken = GenerateRefreshToken();
            var newRefreshTokenValidDate = _dateTime
                .IranNow.AddMinutes(_auth.RefreshTokenAddedExpirationDateValue);

            //deActiveOldRefreshToken
            await _userService.DeActiveRefreshToken(refreshToken.RefToken);


            //generate new and save in db
            await _userService.CreateUserRefreshToken(new UserRefreshToken
            {
                CreatedDate = _dateTime.IranNow,
                ExpirationDate = newRefreshTokenValidDate,
                IpAddress = ipAddress,
                IsInvalidated = false,
                RefreshToken = newRefreshToken,
                Token = newToken,
                UserId = user.Id
            });
            return new ApiResponse(new AuthResponse()
            {
                Token = newToken,
                TokenValidDate = newTokenValidDate,
                RefreshToken = newRefreshToken
            });
        }
        else
        {
            return new ApiResponse(new AuthResponse()
            {
                Token = newToken,
                TokenValidDate = newTokenValidDate,
                RefreshToken = refreshToken.RefToken,
            });
        }
    }

    private async Task<IdentityResult> CreateUserWithoutPassword(User user)
    {
        return await _userManager.CreateAsync(user);
    }

    private async Task<IdentityResult> CreateUserByPassword(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    private List<string> GetIdentityError(IEnumerable<IdentityError> errors)
    {
        var strResult = new List<string>();
        foreach (var item in errors)
        {
            strResult.Add(item.Description);
        }

        return strResult;
    }

    private async Task<JwtSecurityToken> GenerateTokenByUser(User user)
    {
        var claims = await _signInService.GetClaimByUser(user);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_auth.AuthKey));

        return
            new JwtSecurityToken(
                issuer: _auth.AuthIssuer,
                audience: _auth.AuthAudience,
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
    }

    [Obsolete("Obsolete")]
    private string GenerateRefreshToken()
    {
        var byteArray = new byte[32];
        using RNGCryptoServiceProvider cryptProvider = new();
        cryptProvider.GetBytes(byteArray);
        return Convert.ToBase64String(byteArray);
    }
}