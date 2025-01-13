namespace EFSoft.Products.Api.Helpers;

public class EndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/product").WithTags("Products");

        _ = group.MapGet("/{productId:guid}", GetProductEndpoint.GetProduct);

        _ = group.MapPost("/get-products", GetProductsEndpoint.GetProducts)
            .AddEndpointFilter<ValidationFilter<GetProductsRequest>>();

        _ = group.MapPost("/", CreateProductEndpoint.CreateProduct)
            .AddEndpointFilter<ValidationFilter<CreateProductRequest>>();

        _ = group.MapPut("/", UpdateProductEndpoint.UpdateProduct)
            .AddEndpointFilter<ValidationFilter<UpdateProductRequest>>();

        _ = group.MapDelete("/{productId:guid}", DeleteProductEndpoint.DeleteProduct);
    }
}
