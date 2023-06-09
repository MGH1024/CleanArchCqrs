using System.Net;

namespace Application.Models.Responses;

public class ResponseModel
{
    public ApiResponse Response { get; set; }
    public HttpStatusCode Code { get; set; }
}