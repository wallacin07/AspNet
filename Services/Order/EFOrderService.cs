
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
        var order = new ApplicationOrder
        {
            Customer = data.customer,
            CustomerId = data.customer.Id,
            Meals = data.meals,
            Drinks = data.drinks,
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
