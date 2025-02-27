namespace Server.Services.Drink;

using Entities;


public interface IDrinkService
{
    Task<ApplicationDrink?> GetDrink(string drinkId);
    Task<ApplicationDrink> CreateDrink(DrinkData data);
    Task<bool> DeleteDrink(string drinkId); 
    Task<ApplicationDrink[]> GetAllDrinks();

}