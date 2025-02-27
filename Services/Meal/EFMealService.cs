using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Models;

namespace Server.Services.Meal;

public class EFMealService(ParaLanchesDbContext ctx) : IMealService
{
    public async Task<ApplicationMeal> CreateMeal(MealData data)
    {
        var newMeal = new ApplicationMeal{
            Name = data.Name,
            Description = data.Description,
            Price = data.Price
        };

        ctx.Meals.Add(newMeal);
        await ctx.SaveChangesAsync();

        return newMeal;
    }

    public async Task<bool> DeleteMeal(string mealId)
    {
        var meal = await ctx.Meals
        .Where(o => o.Id == Guid.Parse(mealId))
        .FirstOrDefaultAsync();

        if (meal == null)
            return false;

        ctx.Meals.Remove(meal);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<ApplicationMeal[]> GetAllMeals()
    {
        var meals = await ctx.Meals.ToArrayAsync();
        return meals;
    }

    public async Task<ApplicationMeal?> GetMeal(string MealId)
    {
        var meal = await ctx.Meals
        .Where(o => o.Id == Guid.Parse(MealId))
        .FirstOrDefaultAsync();

        if(meal == null)
            return null;

        return meal;
    }
}