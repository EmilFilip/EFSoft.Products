namespace EFSoft.Products.Application.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand;