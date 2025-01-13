namespace EFSoft.Products.Api.DeleteProduct;

public static class DeleteProductEndpoint
{
    public static async Task<IResult> DeleteProduct(
        [FromRoute] Guid productId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var deleteProductCommand = new DeleteProductCommand(productId);

        await mediator.Send(
            deleteProductCommand,
            cancellationToken);

        return Results.Ok();
    }
}
