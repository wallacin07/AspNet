
using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Models;

namespace Server.Services.Order;

public class EFOrderService(ParaLanchesDbContext ctx) : IOrderService
{
    public async Task<bool> CompleteOrder(string orderId)
    {
        var order = await ctx.Orders
        .Where(o => o.CustomerId == Guid.Parse(orderId))
        .FirstOrDefaultAsync();

        if (order == null)
           return false;

        order.OrderCompleted = true;

        await ctx.SaveChangesAsync();

        return true;

    }

    public async Task<ApplicationOrder[]> GetAllOrders()
    {
        var orders = await ctx.Orders.ToListAsync();
        return orders.ToArray();
    }
    public async Task<ApplicationOrder> CreateOrder(OrderData data)
    {

        var drinks = await ctx.Drinks.Where(d => data.drinks.Contains(d.Id.ToString())).ToListAsync();
        var meals = await ctx.Meals.Where(m => data.meals.Contains(m.Id.ToString())).ToListAsync();
        var customer = await ctx.Users.FindAsync(Guid.Parse(data.CustomerId));

        if (customer == null)
            return null;
        
        var order = new ApplicationOrder
        {
            Customer = customer,
            CustomerId = Guid.Parse(data.CustomerId),
            Meals = meals,
            Drinks = drinks,
            TotalPrice = data.totalPrice,
        };

        ctx.Add(order);
        await ctx.SaveChangesAsync();

        return order;
    }

    public async Task<bool> DeleteOrder(string orderId)
    {

        try
        {
            var order = await ctx.FindAsync<ApplicationOrder>(Guid.Parse(orderId));

            if (order == null)
                return false;

            ctx.Orders.Remove(order);
            await ctx.SaveChangesAsync();
            return true;

        }
        catch (DbUpdateException ex)
        {

            Console.WriteLine($"Erro ao deletar ordem: {ex.Message}");
            return false;
        }


    }


    public async Task<ApplicationOrder[]> GetIncompletedOrders()
    {
        var orders = await ctx.Orders
            .Where(o => o.OrderCompleted == false)
            .ToListAsync();

        return orders.ToArray();
    }

    public async Task<ApplicationOrder?> GetOrder(string orderId)
    {
        var order = await ctx.Orders
        .Where(o => o.CustomerId == Guid.Parse(orderId))
        .FirstOrDefaultAsync();

        return order;
    }
}
