namespace EFSoft.Products.Application.Commands.Parameters;

public class CreateProductCommandParameters : ICommand
{
    public CreateProductCommandParameters(
         string description,
         bool inStock)
    {
        Description = description;
        InStock = inStock;
    }

    public string Description { get; }
    public bool InStock { get; }
}
