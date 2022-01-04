namespace EFSoft.Products.Application.Commands.Parameters;

public class DeleteProductCommandParameters : ICommand
{
    public DeleteProductCommandParameters(
         Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; }
}
