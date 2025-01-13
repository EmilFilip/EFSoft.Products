namespace EFSoft.Products.Application.CreateProduct;

public class CreateProductCommandHandler(ICreateProductRepository createProductRepository)
    : ICommandHandler<CreateProductCommand>
{
    public async Task Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var productModel = ProductDomainModel.CreateNew(
            description: command.Description,
            inStock: command.InStock);

        await createProductRepository.CreateProductAsync(
            productModel,
            cancellationToken);
    }
}
