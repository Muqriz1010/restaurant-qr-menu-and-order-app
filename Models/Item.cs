using System.ComponentModel.DataAnnotations;

public class Item
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required String Name { get; set; }

    [Required]
    public Double Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public int MerchantId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public Merchant? Merchant { get; set; }
}