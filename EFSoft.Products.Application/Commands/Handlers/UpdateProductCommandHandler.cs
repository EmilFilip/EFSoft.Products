namespace EFSoft.Products.Application.Commands.Handlers;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommandParameters>
{
    private readonly IProductsRepository _productRepository;

    public UpdateProductCommandHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task HandleAsync(UpdateProductCommandParameters command)
    {
        var productModel = new ProductModel(
            productId: command.ProductId,
            description: command.Description,
            inStock: command.InStock);

        await _productRepository.UpdateProductAsync(productModel);
    }
}
