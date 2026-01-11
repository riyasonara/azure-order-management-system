using AzureOMS.Application.Interfaces;
using AzureOMS.Domain.Entities;
using AzureOMS.Domain.Enums;
using AzureOMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AzureOMS.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _dbContext;

    public OrderService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> CreateOrderService(Guid userId, decimal amount)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Amount = amount,
            Status = OrderStatus.Pending
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(Guid userId,int page,int pageSize,OrderStatus? status)
    {
        var query = _dbContext.Orders
            .Where(o => o.UserId == userId);

        if (status.HasValue)
        {
            query = query.Where(o => o.Status == status);
        }

        return await query
            .OrderByDescending(o => o.CreatedAt).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId) ?? throw new Exception("Order not Found");

        if (order.Status == OrderStatus.Cancelled)
        {
            throw new Exception("Cancelled Orders cannot be updated");
        }

        order.Status = status;
        order.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
    }
}
