namespace EFSoft.Products.Application.GetProduct;

public class GetProductQueryHandler(IGetProductRepository getProductRepository)
    : IQueryHandler<GetProductQuery, GetProductQueryResult?>
{
    public async Task<GetProductQueryResult?> Handle(
            GetProductQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var product = await getProductRepository.GetProductAsync(
            parameters.ProductId,
            cancellationToken);


        if (product is null)
        {
            return default;
        }


        return new GetProductQueryResult(
            Description: product.Description,
            InStock: product.InStock);
    }
}
