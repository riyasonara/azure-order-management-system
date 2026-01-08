using AzureOMS.Domain.Entities;

namespace AzureOMS.Application.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrderService(Guid userId, decimal amount);
    Task<IEnumerable<Order>> GetOrderAsync(Guid userId);
}
