namespace EFSoft.Products.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductsRepository _productRepository;

    public CreateProductCommandHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var productModel = ProductModel.CreateNew(
            description: command.Description,
            inStock: command.InStock);

        await _productRepository.CreateProductAsync(productModel);
    }
}
