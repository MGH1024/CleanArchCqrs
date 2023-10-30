using Api;
using Serilog;
using Persistence;
using Application;
using Infrastructures;
using MGH.Core.Security.Encryption;
using MGH.Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var configurationBuilder = new ConfigurationBuilder();
ApiServiceRegistration.CreateLoggerByConfig(configurationBuilder.GetLogConfig());

var builder = WebApplication.CreateBuilder(args);
Log.Information("web starting up ...");
builder.Services.AddControllers();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructuresServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.AddAuthorization();


const string tokenOptionsConfigurationSection = "TokenOptions";
var tokenOptions =
    builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
    ?? throw new InvalidOperationException($"\"{tokenOptionsConfigurationSection}" +
                                           $"\" section cannot found in configuration.");
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


builder.AddSwagger();
builder.AddBaseMvc();
builder.AddCors();
builder.Host.UseSerilog();
var app = builder.Build();
app.RegisterApp();
app.Run();
