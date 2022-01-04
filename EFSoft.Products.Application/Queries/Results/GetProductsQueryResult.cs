namespace EFSoft.Products.Application.Queries.Results;

public class GetProductsQueryResult : IQueryResult
{
    public GetProductsQueryResult(IEnumerable<ProductModel> products)
    {
        Products = products;
    }

    public IEnumerable<ProductModel> Products { get; }
}
