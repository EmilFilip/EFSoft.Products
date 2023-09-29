namespace EFSoft.Products.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/product");

        group.MapGet("{productId:guid}", Get);
        group.MapGet("", GetProducts);
        group.MapPost("", Post);
        group.MapPut("", Put);
        group.MapDelete("{productId:guid}", Delete);
    }

    public static async Task<Results<Ok<GetProductQueryResult>, NotFound>> Get(
        Guid productId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetProductQuery(productId),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<Results<Ok<GetProductsQueryResult>, NotFound>> GetProducts(
        Guid[] productIds,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetProductsQuery(productIds),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateProductCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateProductCommand parameters,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            parameters,
            cancellationToken);

        return Results.Ok();
    }

    public static async Task<IResult> Delete(
        Guid productId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(
            new DeleteProductCommand(productId),
            cancellationToken);

        return Results.Ok();
    }
}
