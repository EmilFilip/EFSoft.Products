namespace EFSoft.Products.Application.Commands.Handlers;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommandParameters>
{
    private readonly IProductsRepository _productRepository;

    public CreateProductCommandHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task HandleAsync(
        CreateProductCommandParameters command)
    {
        var productModel = ProductModel.CreateNew(
            description: command.Description,
            inStock: command.InStock);

        await _productRepository.CreateProductAsync(productModel);
    }
}
