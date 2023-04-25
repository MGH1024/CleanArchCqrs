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