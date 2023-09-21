namespace EFSoft.Products.Application.Commands.DeleteProduct;

public class DeleteProductCommand : ICommand
{
    public DeleteProductCommand(
         Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; }
}
