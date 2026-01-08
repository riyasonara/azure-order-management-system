namespace AzureOMS.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; } = "Pending";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
