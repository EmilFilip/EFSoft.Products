namespace EFSoft.Products.Api.Configuration;

public class EndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/product").WithTags("Products");

        _ = group.MapGet("/{productId:guid}", GetProductEndpoint.GetProduct);

        _ = group.MapPost("/get-products", GetProductsEndpoint.GetProducts);

        _ = group.MapPost("/", CreateProductEndpoint.CreateProduct);

        _ = group.MapPut("/", UpdateProductEndpoint.UpdateProduct);

        _ = group.MapDelete("/{productId:guid}", DeleteProductEndpoint.DeleteProduct);
    }
}
