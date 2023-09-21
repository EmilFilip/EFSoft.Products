namespace EFSoft.Products.Application.Queries.GetProducts;

public class GetProductsQuery : IQuery<GetProductsQueryResult>
{
    public GetProductsQuery(IEnumerable<Guid> productIds)
    {
        ProductIds = productIds;
    }

    public IEnumerable<Guid> ProductIds { get; set; }
}
