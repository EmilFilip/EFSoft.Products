namespace EFSoft.Products.Application.Queries.Handlers;

public class GetProductQueryHandler :
        IQueryHandler<GetProductQueryParameters, GetProductQueryResult>
{
    private readonly IProductsRepository _productRepository;

    public GetProductQueryHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<GetProductQueryResult> HandleAsync(
            GetProductQueryParameters parameters,
            CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetProductAsync(
            parameters.ProductId,
            cancellationToken);


        if (product is null)
        {
            return null;
        }


        return new GetProductQueryResult(
            description: product.Description,
            inStock: product.InStock);
    }
}
