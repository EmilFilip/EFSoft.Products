namespace EFSoft.Products.Application.Queries.GetProduct;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductQueryResult>
{
    private readonly IProductsRepository _productRepository;

    public GetProductQueryHandler(IProductsRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetProductQueryResult> Handle(
            GetProductQuery parameters,
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
