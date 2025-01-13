namespace EFSoft.Products.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class Services
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .RegisterCqrs(typeof(GetProductQuery).Assembly)
             .AddDbContext<ProductsDbContext>(
                options =>
                {
                    _ = options.UseSqlServer(configuration.GetConnectionString("ProductsConnectionString"), sqlServeroptions =>
                    {
                        _ = sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<ICreateProductRepository, CreateProductRepository>()
             .AddScoped<IDeleteProductRepository, DeleteProductRepository>()
             .AddScoped<IGetProductRepository, GetProductRepository>()
             .AddScoped<IGetProductsRepository, GetProductsRepository>()
             .AddScoped<IUpdateProductRepository, UpdateProductRepository>();
    }
}
