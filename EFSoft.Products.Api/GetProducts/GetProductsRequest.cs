namespace EFSoft.Products.Api.GetProducts;

public sealed record GetProductsRequest(IEnumerable<Guid> ProductIds);
