using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Services.Drink;

public class EFDrinkService(ParaLanchesDbContext ctx) : IDrinkService
{
    public async Task<ApplicationDrink> CreateDrink(DrinkData data)
    {
        var newDrink = new ApplicationDrink{
            Name = data.Name,
            Description = data.Description,
            Price = data.Price
        };

        ctx.Drinks.Add(newDrink);
        await ctx.SaveChangesAsync();

        return newDrink;
    }

    public async Task<bool> DeleteDrink(string drinkId)
    {
        var drink = await ctx.Drinks
        .Where(o => o.Id == Guid.Parse(drinkId))
        .FirstOrDefaultAsync();

        if (drink == null)
            return false;

        ctx.Drinks.Remove(drink);
        await ctx.SaveChangesAsync();
        return true;
    }

    public async Task<ApplicationDrink[]> GetAllDrinks()
    {
        var drinks = await ctx.Drinks.ToArrayAsync();
        return drinks;
    }

    public async Task<ApplicationDrink?> GetDrink(string drinkId)
    {
        var drink = await ctx.Drinks
        .Where(o => o.Id == Guid.Parse(drinkId))
        .FirstOrDefaultAsync();

        if(drink == null)
            return null;

        return drink;
    }
}
