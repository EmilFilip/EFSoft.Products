namespace EFSoft.Products.Application.Queries.Handlers;

public class GetProductsQueryHandler :
    IQueryHandler<GetProductsQueryParameters, GetProductsQueryResult>
{
    private readonly IProductsRepository _productRepository;

    public GetProductsQueryHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<GetProductsQueryResult> HandleAsync(
            GetProductsQueryParameters parameters,
            CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetProductsAsync(
            parameters.ProductIds,
            cancellationToken);

        return new GetProductsQueryResult(products);
    }
}
