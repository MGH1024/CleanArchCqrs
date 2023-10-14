using System.Net.Mime;
using Application.Extensions;
using Application.Models.Responses;
using MGH.Exceptions;
using MGH.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace Application.Middlewares;

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
            catch (GeneralException ex)
            {
                await HandleException(context, ex);
                bodyStream.Seek(0, SeekOrigin.Begin);
                await bodyStream.CopyToAsync(originalBodyStream);
            }
        }
    }

    private static Task HandleException(HttpContext context, GeneralException exception)
    {
        var responseModel = ResponseModelHandler.GetResponseModel(exception);
        context.Response.StatusCode = (int)responseModel.Code;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        if (exception is CustomValidationException)
        {
            
            return context
                .Response
                .WriteAsync(JsonExtensions.ToJsonString(responseModel.Response));
        }
        else
        {
            return context.Response.WriteAsync(JsonExtensions.ToJsonString(responseModel.Response));
        }
    }
}