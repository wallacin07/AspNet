namespace Server.Services.Meal;

using Server.Entities;
using Server.Models;


public interface IMealService
{
    Task<ApplicationMeal?> GetMeal(string MealId);
    Task<ApplicationMeal> CreateMeal(MealData data);
    Task<bool> DeleteMeal(string mealId); 
    Task<ApplicationMeal[]> GetAllMeals();

}