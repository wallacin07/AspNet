namespace Server.Controllers;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Drink;


[Route("drink")]
[ApiController]

public class DrinkController(IDrinkService service
 ) : ControllerBase
{

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateDrinks([FromBody] DrinkData data)
    {
        await service.CreateDrink(data);
        return Ok("Drinks created sucessfully.");
    }

    [HttpGet]
    public async Task<IActionResult> FindAllDrinkss()
    {
        var Drinks = await service.GetAllDrinks();

        if (Drinks.Length == 0)
            return NotFound("Nenhuma ordem encontrada");
  
        return Ok(Drinks);
    }


    [HttpGet("{DrinkId}")]
    public async Task<IActionResult> FindDrinks([FromRoute] string DrinkId)
    {
        var drink = await service.GetDrink(DrinkId);
        return Ok(drink);
    }

    [Authorize]
    [HttpDelete("{DrinkId}")]
    public async Task<IActionResult> DeleteDrink([FromRoute] string DrinkId)
    {
        var deleted = await service.DeleteDrink(DrinkId);
        if (!deleted)
            return BadRequest("Something failed, please check Logs");
        
        return Ok("Drink Deleted with sucess");
    }

}