namespace EFSoft.Products.Application.Queries.Results;

public class GetProductQueryResult : IQueryResult
{
    public GetProductQueryResult(
        string description,
        bool inStock)
    {
        Description = description;
        InStock = inStock;
    }

    public string Description { get; }
    public bool InStock{ get; }
}
