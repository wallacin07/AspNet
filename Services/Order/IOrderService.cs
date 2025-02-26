using Server.Entities;
using Server.Models;

namespace Server.Services.Order;

public interface IOrderService
{
    Task<ApplicationOrder[]> GetIncompletedOrders();
    Task<ApplicationOrder?> GetOrder(string orderId);
    Task<ApplicationOrder> CreateOrder(OrderData data);
    Task<bool> DeleteOrder(string orderId); 

}