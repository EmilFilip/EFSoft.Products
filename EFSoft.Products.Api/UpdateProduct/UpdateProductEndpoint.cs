namespace EFSoft.Products.Api.UpdateProduct;

public static class UpdateProductEndpoint
{
    public static async Task<IResult> UpdateProduct(
        [FromBody] UpdateProductRequest request,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var updateProductCommand = new UpdateProductCommand(
            ProductId: request.ProductId,
            Description: request.Description,
            InStock: request.InStock);

        await mediator.Send(
            updateProductCommand,
            cancellationToken);

        return Results.Ok();
    }
}
