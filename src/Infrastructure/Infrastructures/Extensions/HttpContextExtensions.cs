using Microsoft.AspNetCore.Http;

namespace Infrastructures.Extensions;

public static class HttpContextExtensions
{
    public static bool IsSwaggerRequest(this HttpContext context)
    {
        return context.Request.Path.StartsWithSegments("/swagger");
    }
}