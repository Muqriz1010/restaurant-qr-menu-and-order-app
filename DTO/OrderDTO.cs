
public class OrderDTO
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public required int MerchantId { get; set; }
    public required List<OrderItemDTO>? OrderItems { get; set; }
}