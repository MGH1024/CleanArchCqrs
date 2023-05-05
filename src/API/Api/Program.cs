using Serilog;
using Identity;
using Persistence;
using Application;
using Api.Middleware;
using Infrastructures;
using System.Reflection;
using Mgh.Swagger.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
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
    
    
    //swagger
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    builder.Services.AddSwagger(cfg =>
    {
        cfg.XmlComments = xmlPath;
        cfg.OpenApiInfo = new OpenApiInfo
        {
            Title = "Clean Architecture by CQRS pattern",
            Version = "v1",
            Description = "API"
        };

        var openApiSecurityScheme = new OpenApiSecurityScheme
        {
            Description =
                "just copy token in value TextBox",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
        };

        cfg.OpenApiSecurityScheme = openApiSecurityScheme;
        cfg.OpenApiReference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        };
        cfg.OpenApiSecurityRequirement = new OpenApiSecurityRequirement
        {
            { openApiSecurityScheme, new[] { "Bearer" } }
        };
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureApplicationServices();
    builder.Services.AddTransient<ExceptionHandlingMiddleware>();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddMemoryCache();

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    { 
        options.SuppressModelStateInvalidFilter = true;
    });


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
    app.UseMiddleware<ExceptionHandlingMiddleware>();
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



















