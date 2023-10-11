using System.Net;
using MGH.Exceptions;
using MGH.Exceptions.Base;
using InvalidOperationException = MGH.Exceptions.InvalidOperationException;

namespace Application.Models.Responses
{
    public static class ResponseModelHandler
    {
        public static ResponseModel GetResponseModel(GeneralException exception)
        {
            ApiResponse response;
            var code = exception.StatusCode;

            switch (exception)
            {
                case AuthorizationException:
                    response = new ApiResponse(exception);
                    break;

                case BadRequestException:
                    response = new ApiResponse(exception);
                    break;

                case CustomValidationException:
                    response = new ApiResponse(new List<string> { exception.Message },
                        exception.ValidationErrors);
                    break;

                case DuplicateException:
                    response = new ApiResponse(exception);
                    break;

                case EntityHasReferenceException:
                    response = new ApiResponse(exception);
                    break;

                case EntityNotFoundException:
                    response = new ApiResponse(exception);
                    break;

                case InvalidOperationException:
                    response = new ApiResponse(exception);
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    response = new ApiResponse(exception);
                    break;
            }

            return new ResponseModel
            {
                Code = code,
                Response = response
            };
        }
    }
}