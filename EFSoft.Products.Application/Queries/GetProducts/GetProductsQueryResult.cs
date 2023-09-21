namespace EFSoft.Products.Application.Queries.GetProducts;

public class GetProductsQueryResult
{
    public GetProductsQueryResult(IEnumerable<ProductModel> products)
    {
        Products = products;
    }

    public IEnumerable<ProductModel> Products { get; }
}
