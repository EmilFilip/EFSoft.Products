namespace EFSoft.Products.Application.Commands.CreateProduct;

public sealed record CreateProductCommand(
         string Description,
         bool InStock) : ICommand;
