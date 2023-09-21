namespace EFSoft.Products.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .AddDbContext<ProductsDbContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("ProductsConnectionString"), sqlServeroptions =>
                    {
                        sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<IProductsRepository, ProductsRepository>();
    }
}