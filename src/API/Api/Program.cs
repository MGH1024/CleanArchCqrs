using Serilog;
using Identity;
using Persistence;
using Application;
using Api.Middleware;
using Infrastructures;

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
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureApplicationServices();
    builder.Services.AddTransient<ExceptionHandlingMiddleware>();
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



















