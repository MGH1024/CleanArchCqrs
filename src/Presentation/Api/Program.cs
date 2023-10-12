using Api;
using Serilog;
using Persistence;
using Application;
using Application.Models.Security;
using Infrastructures;
using Infrastructures.Extensions.SecurityHelpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var configurationBuilder = new ConfigurationBuilder();
ApiServiceRegistration.CreateLoggerByConfig(configurationBuilder.GetLogConfig());

try
{
    var builder = WebApplication.CreateBuilder(args);
    Log.Information("web starting up ...");

    builder.AddSwagger();
    builder.AddBaseMvc();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureApplicationServices();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddMemoryCache();
    builder.Services.ConfigurePersistenceService(builder.Configuration);
    builder.Services.ConfigureInfrastructuresServices(builder.Configuration);
    builder.AddCors();
    builder.AddToken();
    builder.AddAuthorization();

   
    
    
    builder.Host.UseSerilog();

    

    var app = builder.Build();
    app.RegisterApp();
    app.Run();
}
catch (Exception ex)
{
    var type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
        throw;

    Log.Fatal(ex, "Error in web Unhandled exception");
}
finally
{
    Log.CloseAndFlush();
}