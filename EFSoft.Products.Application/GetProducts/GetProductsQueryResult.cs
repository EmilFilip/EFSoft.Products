namespace EFSoft.Products.Application.GetProducts;

public sealed record GetProductsQueryResult(IEnumerable<ProductDomainModel> Products);
