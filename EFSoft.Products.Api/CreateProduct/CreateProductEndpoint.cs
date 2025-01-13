namespace EFSoft.Products.Api.CreateProduct;

public static class CreateProductEndpoint
{
    public static async Task<IResult> CreateProduct(
        [FromBody] CreateProductRequest request,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var createProductCommand = new CreateProductCommand(
            Description: request.Description,
            InStock: request.InStock);

        await mediator.Send(
            createProductCommand,
            cancellationToken);

        return Results.Ok();
    }
}
