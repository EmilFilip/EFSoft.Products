namespace EFSoft.Products.Application.Commands.UpdateProduct;

public class UpdateProductCommand : ICommand
{
    public UpdateProductCommand(
         Guid productId,
         string description,
         bool inStock)
    {
        ProductId = productId;
        Description = description;
        InStock = inStock;
    }

    public Guid ProductId { get; }

    public string Description { get; }

    public bool InStock { get; }
}
