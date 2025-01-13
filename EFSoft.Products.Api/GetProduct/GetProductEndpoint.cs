namespace EFSoft.Products.Api.GetProduct;

public static class GetProductEndpoint
{
    public static async Task<Results<Ok<GetProductQueryResult>, NotFound>> GetProduct(
        [FromRoute] Guid productId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var getCustomerQuery = new GetProductQuery(productId);

        var results = await mediator.Send(
            getCustomerQuery,
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}
