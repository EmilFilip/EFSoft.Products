namespace EFSoft.Products.Application.Queries.GetProducts;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsQueryResult>
{
    private readonly IProductsRepository _productRepository;

    public GetProductsQueryHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetProductsQueryResult> Handle(
            GetProductsQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetProductsAsync(
            productIds: parameters.ProductIds,
            cancellationToken: cancellationToken);

        return new GetProductsQueryResult(products);
    }
}
