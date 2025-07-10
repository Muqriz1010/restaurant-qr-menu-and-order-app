public class OrderResponseDTO
{
    public int Id { get; set; }
    public required string OrderUUID { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Status { get; set; }
    public double TotalPrice { get; set; }
    public required List<OrderItemResponseDTO> OrderItems { get; set; }
}