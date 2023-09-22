namespace EFSoft.Products.Application.Commands.UpdateProduct;

public sealed record class UpdateProductCommand(
         Guid ProductId,
         string Description,
         bool InStock) : ICommand
{
}
