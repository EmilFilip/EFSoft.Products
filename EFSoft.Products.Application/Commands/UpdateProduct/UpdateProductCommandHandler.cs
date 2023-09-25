namespace EFSoft.Products.Application.Commands.UpdateProduct;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductsRepository _productRepository;

    public UpdateProductCommandHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(
        UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var productModel = new ProductModel(
            productId: command.ProductId,
            description: command.Description,
            inStock: command.InStock);

        await _productRepository.UpdateProductAsync(
            productModel,
            cancellationToken);
    }
}
