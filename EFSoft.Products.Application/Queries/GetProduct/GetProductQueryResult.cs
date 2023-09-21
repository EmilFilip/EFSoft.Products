namespace EFSoft.Products.Application.Queries.GetProduct;

public class GetProductQueryResult
{
    public GetProductQueryResult(
        string description,
        bool inStock)
    {
        Description = description;
        InStock = inStock;
    }

    public string Description { get; }
    public bool InStock { get; }
}
