namespace EFSoft.Products.Application.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand;