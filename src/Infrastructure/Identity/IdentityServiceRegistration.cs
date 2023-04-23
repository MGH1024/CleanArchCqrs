﻿using System.Text;
using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using Domain;
using Domain.Identity;
using Identity.Configurations.IdentityConfig;
using Identity.Repositories;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Identity;

public static class IdentityServiceRegistration
{
    public static IServiceCollection ConfigureIdentityService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var sqlConfig = configuration
            .GetSection(nameof(DbConnection))
            .Get<DbConnection>()
            .SqlConnection;

        services.AddHealthChecks()
            .AddDbContextCheck<AppIdentityDbContext>();

        services
            .AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(sqlConfig));

        var auth = configuration.GetSection(nameof(Auth)).Get<Auth>();

        services.AddIdentity<User, Role>(op =>
            {
                // Password settings.
                op.Password.RequireDigit = auth.PasswordRequireDigit;
                op.Password.RequireLowercase = auth.PasswordRequireLowercase;
                op.Password.RequireNonAlphanumeric = auth.PasswordRequireNonAlphanumeric;
                op.Password.RequireUppercase = auth.PasswordRequireUppercase;
                op.Password.RequiredLength = auth.PasswordRequiredLength;
                op.Password.RequiredUniqueChars = auth.PasswordRequiredUniqueChars;


                // Lockout settings.
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(auth.LockoutDefaultLockoutTimeSpan);
                op.Lockout.MaxFailedAccessAttempts = auth.LockoutMaxFailedAccessAttempts;
                op.Lockout.AllowedForNewUsers = auth.LockoutAllowedForNewUsers;

                // User settings.
                op.User.AllowedUserNameCharacters = auth.AllowedUserNameCharacters;
                op.User.RequireUniqueEmail = auth.UserRequireUniqueEmail;
            })
            .AddRoles<Role>()
            .AddPasswordValidator<PasswordValidator>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddErrorDescriber<PersianIdentityErrorDescriber>()
            .AddDefaultTokenProviders();
        
        
        
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(auth.AuthKey);
                jwt.SaveToken = auth.SaveToken;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = auth.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = auth.ValidateIssuer,
                    ValidateAudience = auth.ValidateAudience,
                    RequireExpirationTime = auth.RequireExpirationTime,
                    ValidateLifetime = auth.ValidateLifetime,

                };
            });
        
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IPermissionService, PermissionService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IClaimService, ClaimService>();
        services.AddTransient<ISignInService, SignInService>();
        
        services.AddTransient<IUserRepository, UserRepository>();
        
        return services;
    }
}