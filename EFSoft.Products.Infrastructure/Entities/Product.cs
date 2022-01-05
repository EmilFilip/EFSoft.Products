namespace EFSoft.Products.Infrastructure.Entities;

public class Product
{
    [Key]
    public Guid ProductId { get; set; }

    [Required]
    public string Description { get; set; }

    public bool InStock { get; set; }

    public bool Deleted { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}