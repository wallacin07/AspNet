using Server.Entities;

namespace Server.Services.Ingredient;


public interface IIngredientService
{
    public Task<ApplicationIngredient> AddIngredient();
    public Task<ApplicationIngredient> RemoveIngredient();
    public Task<ApplicationIngredient[]> getAllIngredients();
}