using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Order;

namespace Server.Controllers;

[Route("order")]
[ApiController]

public class OrderController(IOrderService service,
 ConfigurationManager config
 ) : ControllerBase
{

  
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderData data)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> FindoAllOrders()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{OrderId}")]
    public async Task<IActionResult> FindOrder([FromRoute] string OrderId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{OrderId}")]
    public async Task<IActionResult> DeleteOrdem([FromRoute] string OrderId)
    {
        throw new NotImplementedException();
    }

}