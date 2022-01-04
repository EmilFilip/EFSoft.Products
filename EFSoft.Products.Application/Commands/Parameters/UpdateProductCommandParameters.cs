namespace EFSoft.Products.Application.Commands.Parameters;

public class UpdateProductCommandParameters : ICommand
{
    public UpdateProductCommandParameters(
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
