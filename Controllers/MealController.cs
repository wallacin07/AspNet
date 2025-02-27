namespace Server.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Meal;


[Route("meal")]
[ApiController]

public class MealController(IMealService service
 ) : ControllerBase
{

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateMeals([FromBody] MealData data)
    {
        await service.CreateMeal(data);
        return Ok("Meals created sucessfully.");
    }

    [HttpGet]
    public async Task<IActionResult> FindAllMealss()
    {
        var Meals = await service.GetAllMeals();

        if (Meals.Length == 0)
            return NotFound("Nenhuma ordem encontrada");
  
        return Ok(Meals);
    }


    [HttpGet("{MealId}")]
    public async Task<IActionResult> FindMeals([FromRoute] string MealId)
    {
        var meals = await service.GetMeal(MealId);
        return Ok(meals);
    }

    [Authorize]
    [HttpDelete("{MealId}")]
    public async Task<IActionResult> DeleteMeal([FromRoute] string MealId)
    {
        var deleted = await service.DeleteMeal(MealId);
        if (!deleted)
            return BadRequest("Something failed, please check Logs");
        
        return Ok("Meal Deleted with sucess");
    }

}