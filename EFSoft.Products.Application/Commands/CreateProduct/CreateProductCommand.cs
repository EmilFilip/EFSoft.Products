namespace EFSoft.Products.Application.Commands.CreateProduct;

public class CreateProductCommand : ICommand
{
    public CreateProductCommand(
         string description,
         bool inStock)
    {
        Description = description;
        InStock = inStock;
    }

    public string Description { get; }
    public bool InStock { get; }
}
