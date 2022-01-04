namespace EFSoft.Products.Application.Commands.Handlers;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommandParameters>
{
    private readonly IProductsRepository _productRepository;

    public DeleteProductCommandHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task HandleAsync(DeleteProductCommandParameters command)
    {
        await _productRepository.DeleteProductAsync(command.ProductId);
    }
}
