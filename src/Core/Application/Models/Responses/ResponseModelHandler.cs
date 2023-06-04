using System.Net;
using Application.Exceptions;
using Application.Exceptions.Base;
using Application.Exceptions.Validation;

namespace Application.Models.Responses
{
    public static class ResponseModelHandler
    {
        public static ResponseModel GetResponseModel(Exception exception)
        {
            ApiResponse response;
            HttpStatusCode code;

            if (exception is AppException)
            {
                var ex = exception as AppException;
                if (exception is CustomValidationException)
                {
                    code = HttpStatusCode.BadRequest;
                    response = new ApiResponse(ex.Messages, ex.Errors);
                }
                else if (exception is NotFoundException)
                {
                    code = HttpStatusCode.NotFound;
                    response = new ApiResponse(ex);
                }
                else
                {
                    code = HttpStatusCode.UnprocessableEntity;
                    response = new ApiResponse(ex);
                }
            }
            else if (exception is UnauthorizedAccessException)
            {
                response = new ApiResponse();
                code = HttpStatusCode.Unauthorized;
            }
            else
            {
                response = new ApiResponse(exception);
                code = HttpStatusCode.InternalServerError;
            }

            return new ResponseModel
            {
                Code = code,
                Response = response
            };
        }
    }

    public class ResponseModel
    {
        public ApiResponse Response { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
