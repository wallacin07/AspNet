using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("/")]
[ApiController]

public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    => Ok("Server Running...");
}