using AzureOMS.Domain.Common;
using AzureOMS.Domain.Enums;

namespace AzureOMS.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
}
