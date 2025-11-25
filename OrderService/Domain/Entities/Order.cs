namespace OrderService.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ItemsJson { get; set; } = string.Empty;

    public decimal Total { get; set; }

    public string Status { get; set; } = "Pending";
}