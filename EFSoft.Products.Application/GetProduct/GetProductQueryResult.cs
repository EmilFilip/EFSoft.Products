namespace EFSoft.Products.Application.GetProduct;

public sealed record GetProductQueryResult(
        Guid ProductId,
        string Description,
        bool InStock);
