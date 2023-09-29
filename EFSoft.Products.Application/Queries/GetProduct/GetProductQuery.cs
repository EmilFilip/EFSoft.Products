namespace EFSoft.Products.Application.Queries.GetProduct;

public sealed record GetProductQuery(Guid ProductId) : IQuery<GetProductQueryResult>;