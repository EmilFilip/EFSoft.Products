namespace EFSoft.Products.Application.Commands.DeleteProduct;

public sealed record class DeleteProductCommand(Guid ProductId) : ICommand
{
}
