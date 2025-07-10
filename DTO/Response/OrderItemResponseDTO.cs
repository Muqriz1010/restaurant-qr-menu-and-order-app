
public class OrderItemResponseDTO
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public required string ItemName { get; set; } 
    public double Price { get; set; }
}