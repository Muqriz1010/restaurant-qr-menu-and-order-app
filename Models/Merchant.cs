using System.ComponentModel.DataAnnotations;

public class Merchant
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
}