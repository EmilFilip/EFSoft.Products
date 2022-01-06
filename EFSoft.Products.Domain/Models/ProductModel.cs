namespace EFSoft.Products.Domain.Models;

public class ProductModel
{
    public ProductModel(
           Guid productId,
           string description,
           bool inStock)
    {
        ProductId = productId;
        Description = description;
        InStock = inStock;
    }

    public static ProductModel CreateNew(
        string description,
        bool inStock)
    {
        return new ProductModel(
            productId: Guid.NewGuid(),
            description: description,
            inStock: inStock);
    }

    public Guid ProductId { get; }

    public string Description { get; set; }

    public bool InStock { get; }
}
