namespace Server.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Server.Models;
using Server.Services.Order;


[Route("order")]
[ApiController]

public class OrderController(IOrderService service
 ) : ControllerBase
{

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderData data)
    {
        await service.CreateOrder(data);
        return Ok("Order created sucessfully.");
    }

    [HttpGet]
    public async Task<IActionResult> FindAllOrders()
    {
        var Orders = await service.GetAllOrders();

        if (Orders.Length == 0)
            return NotFound("Nenhuma ordem encontrada");
  
        return Ok(Orders);
    }

    [HttpGet("NotCompleted")]
    public async Task<IActionResult> FindOrdersNotCompleted()
    {
        var OrdersNotCompleted = await service.GetIncompletedOrders();

        if (OrdersNotCompleted.Length == 0)
            return NotFound("Nenhuma ordem encontrada");
  
        return Ok(OrdersNotCompleted);

    }

    [Authorize]
    [HttpPatch("{OrderId}")]
    public async Task<IActionResult> CompleteOrder([FromRoute] string OrderId)
    {
        var Order = await service.CompleteOrder(OrderId);
        if (Order == false)
            return NotFound("Nenhuma ordem encontrada");
        
        return Ok("Ordem Completada com sucesso");
    }

    [HttpGet("{OrderId}")]
    public async Task<IActionResult> FindOrder([FromRoute] string OrderId)
    {
        var order = await service.GetOrder(OrderId);
        return Ok(order);
    }

    [Authorize]
    [HttpDelete("{OrderId}")]
    public async Task<IActionResult> DeleteOrdem([FromRoute] string OrderId)
    {
        var deleted = await service.DeleteOrder(OrderId);
        if (!deleted)
            return BadRequest("Something failed, please check Logs");
        
        return Ok("Order Deleted with sucess");
    }

}