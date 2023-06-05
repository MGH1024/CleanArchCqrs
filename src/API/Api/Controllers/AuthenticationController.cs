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
    public async Task<IActionResult> Login([FromBody] AuthRequestDto authRequestDto)
    {
        var command = new AuthCommand { AuthRequestDto = authRequestDto,IpAddress=IpAddress };
        return Ok(await Sender.Send(command));
    }
    
    [HttpGet]
    [Route("get-user-by-token")]
    public async Task<IActionResult> GetUserNameByToken([FromQuery] GetUserByTokenDto getUserByTokenDto)
    {
        var query = new GetUserByTokenQuery { GetUserByTokenDto = getUserByTokenDto };
        return Ok(await Sender.Send(query));
    }
}