namespace EFSoft.Products.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IProductsRepository _productRepository;

    public DeleteProductCommandHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        await _productRepository.DeleteProductAsync(command.ProductId);
    }
}
