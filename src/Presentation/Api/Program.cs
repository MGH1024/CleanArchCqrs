using Api;
using Serilog;
using Persistence;
using Application;
using Infrastructures;

var configurationBuilder = new ConfigurationBuilder();
ApiServiceRegistration.CreateLoggerByConfig(configurationBuilder.GetLogConfig());

try
{
    var builder = WebApplication.CreateBuilder(args);
    Log.Information("web starting up ...");

    builder.Services.AddControllers();
    builder.Services.AddApplicationServices();
    builder.Services.AddPersistenceService(builder.Configuration);
    builder.Services.AddInfrastructuresServices(builder.Configuration);
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddMemoryCache();
   
    builder.AddCors();
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