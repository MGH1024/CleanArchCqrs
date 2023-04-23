using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public abstract class AppController:ControllerBase
{
    protected readonly ISender Sender;

    protected AppController(ISender sender)
    {
        Sender = sender;
    }
}