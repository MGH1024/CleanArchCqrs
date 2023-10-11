using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Authentications.Commands.Login;
using Application.Features.Authentications.Commands.RegisterUser;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : AppController
{

    public AuthenticationController(ISender sender) : base(sender)
    {
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        var command = new LoginCommand { UserLoginDto = userLoginDto };
        return Ok(await Sender.Send(command));
    }
    
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterUserDto registerUserDto)
    {
        var command = new RegisterCommand{RegisterUserDto =registerUserDto };

        return Ok(await Sender.Send(command));
    }
    
    // [HttpGet]
    // [Route("get-user-by-token")]
    // public async Task<IActionResult> GetUserNameByToken([FromQuery] GetUserByTokenDto getUserByTokenDto)
    // {
    //     var query = new GetUserByTokenQuery { GetUserByTokenDto = getUserByTokenDto };
    //     return Ok(await Sender.Send(query));
    // }
}