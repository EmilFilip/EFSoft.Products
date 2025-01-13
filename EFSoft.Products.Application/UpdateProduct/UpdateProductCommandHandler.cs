namespace EFSoft.Products.Application.UpdateProduct;

public class UpdateProductCommandHandler(IUpdateProductRepository updateProductRepository)
    : ICommandHandler<UpdateProductCommand>
{
    public async Task Handle(
        UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var productModel = new ProductDomainModel(
            productId: command.ProductId,
            description: command.Description,
            inStock: command.InStock);

        await updateProductRepository.UpdateProductAsync(
            productModel,
            cancellationToken);
    }
}
