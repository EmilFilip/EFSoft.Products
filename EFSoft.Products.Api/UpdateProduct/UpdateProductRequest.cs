namespace EFSoft.Products.Api.UpdateProduct;

public sealed record UpdateProductRequest(
         Guid ProductId,
         string Description,
         bool InStock);
