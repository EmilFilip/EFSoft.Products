namespace EFSoft.Products.Application.Queries.Parameters;

public class GetProductQueryParameters : IQueryParameters
{
    public GetProductQueryParameters(Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
}
