namespace EFSoft.Products.Application.Queries.GetProduct;

public sealed record class GetProductQuery(Guid ProductId) : IQuery<GetProductQueryResult>
{
}
