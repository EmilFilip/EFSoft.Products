namespace EFSoft.Products.Api.Endpoints
{
    public static class ProductEndpoint
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder endpoint)
        {
            var group = endpoint.MapGroup("api/product");

            group.MapGet("{productId:guid}", Get);
            group.MapPost("", Post);
            group.MapPut("", Put);
            group.MapDelete("{productId:guid}", Delete);
        }

        public static async Task<Results<Ok<GetProductQueryResult>, NotFound>> Get(
            Guid productId,
            IMediator mediator)
        {
            var results = await mediator.Send(new GetProductQuery(productId));

            if (results == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(results);
        }

        public static async Task<IResult> Post(
            [FromBody] CreateProductCommand parameters,
            IMediator mediator)
        {
            await mediator.Send(parameters);

            return Results.Ok();
        }

        public static async Task<IResult> Put(
            [FromBody] UpdateProductCommand parameters,
            IMediator mediator)
        {
            await mediator.Send(parameters);

            return Results.Ok();
        }

        public static async Task<IResult> Delete(
            Guid customerId,
            IMediator mediator)
        {
            await mediator.Send(new DeleteProductCommand(customerId));

            return Results.Ok();
        }
    }
}
