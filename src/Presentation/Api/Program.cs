using Serilog;
using Identity;
using MGH.Swagger;
using Persistence;
using Application;
using MGH.Exceptions;
using Infrastructures;
using MGH.Exceptions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Infrastructures.Middlewares;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;

var serilogConfig = new ConfigurationBuilder()
    .AddJsonFile("logSettings.json", optional: true, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(serilogConfig)
    .CreateLogger();


try
{
    var builder = WebApplication
        .CreateBuilder(args);
    Log.Information("web starting up ...");

    builder.Services.AddSwaggerGen();
    
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

    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(opt =>
        {
            opt.InvalidModelStateResponseFactory = (ctx) =>
            {
                var modelState = ctx.ModelState;
                var errors = modelState
                    .Keys
                    .SelectMany(key => modelState[key]
                        .Errors
                        .Select(err => new ValidationError(key.Replace("$.", ""), err.ErrorMessage)));
                throw new CustomValidationException(errors);
               
            };
        });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureApplicationServices();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddMemoryCache();

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


    builder.Services.ConfigureIdentityService(builder.Configuration);
    builder.Services.ConfigurePersistenceService(builder.Configuration);
    builder.Services.ConfigureInfrastructuresServices(builder.Configuration);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

    builder.Host.UseSerilog();
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseMiddleware<ApiResponseMiddleware>();
    app.UseAuthorization();
    app.UseCors("CorsPolicy");
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    var type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }

    Log.Fatal(ex, "Error in web Unhandled exception");
}
finally
{
    Log.CloseAndFlush();
}