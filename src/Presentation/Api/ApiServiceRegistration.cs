using System.Text.Json.Serialization;
using Application.Middlewares;
using Application.Models.Security;
using MGH.Core.Security.Encryption;
using MGH.Core.Security.JWT;
using MGH.Exceptions;
using MGH.Exceptions.Models;
using MGH.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Api;

public static class ApiServiceRegistration
{
    public static IConfigurationRoot GetLogConfig(this ConfigurationBuilder configurationBuilder)
    {
        return configurationBuilder
            .AddJsonFile("logSettings.json", optional: true, reloadOnChange: true)
            .Build();
    }

    public static void CreateLoggerByConfig(IConfigurationRoot configurationRoot)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configurationRoot)
            .CreateLogger();
    }

    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(op =>
        {
            op.AddXmlComments();
            op.AddBearerToken(new OpenApiSecurityScheme
            {
                Description = "just copy token in value TextBox",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            });
            op.AddSwaggerDoc(new OpenApiInfo
            {
                Title = "Clean Architecture by CQRS pattern",
                Version = "v1",
                Description = "API"
            });
        });
    }

    public static void AddBaseMvc(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = (ctx) =>
                {
                    var modelState = ctx.ModelState;
                    var errors = modelState
                        .Keys
                        .SelectMany(key => modelState[key]?
                            .Errors
                            .Select(err => new ValidationError(key.Replace("$.", ""), err.ErrorMessage)));
                    throw new CustomValidationException(errors);
                };
            });

        builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

        builder.Services.AddMvc(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
                setup.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
    }

    public static void AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                config => config.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static void AddAuthorization(this WebApplicationBuilder builder)
    {
        var admin = builder.Configuration.GetSection("Policies").Get<Policies>().Admin;
        builder.Services.AddAuthorization(op =>
        {
            op.AddPolicy("Admin", policy =>
                policy.RequireRole(admin));
        });
    }

    public static void AddAuthentication(this WebApplicationBuilder builder)
    {
        const string tokenOptionsConfigurationSection = "TokenOptions";
        var tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>();
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
    }

    public static void RegisterApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.UseMiddleware<ApiResponseMiddleware>();
        app.UseCors("CorsPolicy");
        app.MapControllers();
    }
}