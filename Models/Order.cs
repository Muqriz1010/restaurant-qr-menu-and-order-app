using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    public int Id { get; set; }
    public string OrderUUID { get; set; } = GenerateOrderId();
    public DateTime CreatedAt { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
    public string Status { get; set; } = "Pending";
    public double TotalPrice { get; set; } = 0.0;
    public int? MerchantId { get; set; }
    public Merchant? Merchant { get; set; }
    
    private static string GenerateOrderId() => Guid.NewGuid().ToString();
}