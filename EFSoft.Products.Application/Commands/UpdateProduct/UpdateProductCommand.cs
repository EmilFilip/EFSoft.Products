namespace EFSoft.Products.Application.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
         Guid ProductId,
         string Description,
         bool InStock) : ICommand;