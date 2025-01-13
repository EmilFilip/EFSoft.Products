namespace EFSoft.Products.Application.GetProducts;

public sealed record GetProductsQuery(IEnumerable<Guid> ProductIds) : IQuery<GetProductsQueryResult>;
