using Application.DTOs.Auth;
using Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Models.Identity;
using Application.Features.Authentications.Commands.Auth;
using Application.Features.Authentications.Queries.GetUserByToken;

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
    
    [HttpGet]
    [Route("get-user-by-token")]
    public async Task<IActionResult> GetUserNameByToken([FromQuery] GetUserByToken getUserByToken)
    {
        var query = new GetUserByTokenQuery { GetUserByToken = getUserByToken };
        return Ok(await Sender.Send(query));
    }
}