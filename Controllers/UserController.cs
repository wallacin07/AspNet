
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Token;
using Server.Services.User;

namespace Server.Controllers;

[Route("/user")]
[ApiController]

public class UserController(IUserService service,
 ConfigurationManager config,
 JWTService jwtService
 ) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AccountData data)
    {
        await service.CreateUser(data);

        return Ok("User creatd succesfully");
    }

    [Authorize]
    [HttpGet("/invitation")]
    public IActionResult GetInvitationUrl()
    {
         var userId =  Guid.Empty;
         var localHost = config.GetClientUrl;
        //  var localHost = config["FrontEndURL"]; JEITO CERTO
         return Ok($"{localHost}/invitation/{userId}");
    }


    [HttpPost("/invitation/{invite}")]
    public async Task<IActionResult> CreateUserWithInvite([FromBody] AccountData accountData,[FromRoute]Guid invite)
    {
        await service.CreateUser(accountData, invite);
        return  Ok("User Created succesfully");
    }

    [HttpPost("/auth")]
    public async Task<IActionResult> Login([FromBody] LoginData loginData)
    {
        var user = await service.Authenticate(loginData);
        if (user == null)
            return Unauthorized();

        var jwt = jwtService.Generate(user);

        return Ok(new {jwt});

    }
}