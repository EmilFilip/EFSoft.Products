namespace EFSoft.Products.Application.Queries.Parameters;

public class GetProductsQueryParameters : IQueryParameters
{
    public GetProductsQueryParameters(IEnumerable<Guid> productIds)
    {
        ProductIds = productIds;
    }

    public IEnumerable<Guid> ProductIds { get; set; }
}
