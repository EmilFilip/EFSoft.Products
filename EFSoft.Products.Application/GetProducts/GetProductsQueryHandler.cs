namespace EFSoft.Products.Application.GetProducts;

public class GetProductsQueryHandler(IGetProductsRepository getProductsRepository)
    : IQueryHandler<GetProductsQuery, GetProductsQueryResult>
{
    public async Task<GetProductsQueryResult> Handle(
            GetProductsQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var products = await getProductsRepository.GetProductsAsync(
            productIds: parameters.ProductIds,
            cancellationToken: cancellationToken);

        return new GetProductsQueryResult(products);
    }
}
