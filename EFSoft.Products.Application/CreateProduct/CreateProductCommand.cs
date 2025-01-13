namespace EFSoft.Products.Application.CreateProduct;

public sealed record CreateProductCommand(
         string Description,
         bool InStock) : ICommand;
