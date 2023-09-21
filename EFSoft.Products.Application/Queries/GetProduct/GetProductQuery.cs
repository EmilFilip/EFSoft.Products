namespace EFSoft.Products.Application.Queries.GetProduct;

public class GetProductQuery : IQuery<GetProductQueryResult>
{
    public GetProductQuery(Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
}
