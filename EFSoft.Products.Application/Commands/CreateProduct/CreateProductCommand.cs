namespace EFSoft.Products.Application.Commands.CreateProduct;

public sealed record class CreateProductCommand(
         string Description,
         bool InStock) : ICommand
{
}
