using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Models.Identity;
using Application.Features.Authentications.Commands.Auth;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : AppController
{

    public AuthenticationController(ISender sender) : base(sender)
    {
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
    {
        var command = new AuthCommand { AuthRequest = authRequest,IpAddress=IpAddress };
        return Ok(await Sender.Send(command));
    }
}