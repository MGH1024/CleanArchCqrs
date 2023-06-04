using System.Net.Mime;
using Application.Models.Responses;
using Infrastructures.Extensions;
using Microsoft.AspNetCore.Http;

namespace Infrastructures.Middlewares;

public class ApiResponseMiddleware
{
    private readonly RequestDelegate _next;
    public ApiResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.IsSwaggerRequest())
            await _next(context);
        else
        {
            var originalBodyStream = context.Response.Body;

            using var bodyStream = new MemoryStream();
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
                bodyStream.Seek(0, SeekOrigin.Begin);
                await bodyStream.CopyToAsync(originalBodyStream);
            }
        }
    }

    private static Task HandleException(HttpContext context, Exception exception)
    {
        var responseModel = ResponseModelHandler.GetResponseModel(exception);
        context.Response.StatusCode = (int)responseModel.Code;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        return context.Response.WriteAsync(JsonExtensions.ToJsonString(responseModel.Response));
    }
}