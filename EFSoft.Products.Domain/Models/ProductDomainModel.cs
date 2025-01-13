namespace EFSoft.Products.Domain.Models;

public class ProductDomainModel
{
    public ProductDomainModel(
           Guid productId,
           string description,
           bool inStock)
    {
        ProductId = productId;
        Description = description;
        InStock = inStock;
    }

    public static ProductDomainModel CreateNew(
        string description,
        bool inStock)
    {
        return new ProductDomainModel(
            productId: Guid.NewGuid(),
            description: description,
            inStock: inStock);
    }

    public Guid ProductId { get; }

    public string Description { get; set; }

    public bool InStock { get; }
}
