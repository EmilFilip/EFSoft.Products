namespace EFSoft.Products.Api.GetProducts;

public static class GetProductsEndpoint
{
    public static async Task<Results<Ok<GetProductsQueryResult>, NotFound>> GetProducts(
        [FromBody] GetProductsRequest getProductsRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var getProductsQuery = new GetProductsQuery(getProductsRequest.ProductIds);

        var results = await mediator.Send(
            getProductsQuery,
            cancellationToken);

        if (!results.Products.Any())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}
