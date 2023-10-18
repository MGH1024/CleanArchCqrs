using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public abstract class AppController : ControllerBase
{
    protected readonly ISender Sender;

    protected AppController(ISender sender)
    {
        Sender = sender;
    }

    protected string IpAddress =>
        HttpContext.Connection.RemoteIpAddress != null ? HttpContext.Connection.RemoteIpAddress.ToString() : "";
    
    protected string GetIpAddress()
    {
        var ipAddress = Request.Headers.TryGetValue("X-Forwarded-For", out var header)
            ? header.ToString()
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
              ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
        return ipAddress;
    }

    protected string CurrentUser
    {
        get
        {
            var name =
                User.Claims
                    .FirstOrDefault(x => x.Type
                        .Equals("userName", StringComparison.InvariantCultureIgnoreCase));
            return name == null ? "" : name.Value;
        }
    }
}