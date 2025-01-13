namespace EFSoft.Products.Application.UpdateProduct;

public sealed record UpdateProductCommand(
         Guid ProductId,
         string Description,
         bool InStock) : ICommand;