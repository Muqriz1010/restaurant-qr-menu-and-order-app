public class OrderResponseDTO
{
    public int Id { get; set; }
    public string OrderUUID { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public double TotalPrice { get; set; }
    public List<OrderItemDTO> OrderItems { get; set; }
}