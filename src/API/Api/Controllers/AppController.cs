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

    protected string IpAddress
    {
        get
        {
            return HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }

    protected string CurrentUser
    {
        get
        {
            var name =
                User.Claims
                .FirstOrDefault(x => x.Type.Equals("userName", StringComparison.InvariantCultureIgnoreCase));
            if (name == null)
                return "";
            return name.Value;
        }
    }
}