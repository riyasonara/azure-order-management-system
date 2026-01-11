using AzureOMS.Domain.Entities;
using AzureOMS.Domain.Enums;

namespace AzureOMS.Application.Interfaces;

public interface IOrderService
{
    Task<Order> CreateOrderService(Guid userId, decimal amount);

    Task<IEnumerable<Order>> GetOrdersAsync(
    Guid userId,
    int page,
    int pageSize,
    OrderStatus? status);

    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
}
