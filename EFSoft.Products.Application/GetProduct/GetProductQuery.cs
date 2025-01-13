namespace EFSoft.Products.Application.GetProduct;

public sealed record GetProductQuery(Guid ProductId) : IQuery<GetProductQueryResult>;