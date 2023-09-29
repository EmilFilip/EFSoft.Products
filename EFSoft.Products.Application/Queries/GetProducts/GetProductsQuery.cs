namespace EFSoft.Products.Application.Queries.GetProducts;

public sealed record GetProductsQuery(IEnumerable<Guid> ProductIds) : IQuery<GetProductsQueryResult>;
