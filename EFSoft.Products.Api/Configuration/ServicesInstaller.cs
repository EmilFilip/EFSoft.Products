namespace EFSoft.Products.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .AddCqrs(configurator =>
                    configurator.AddHandlers(typeof(GetProductQueryParameters).Assembly))
             .AddDbContext<ProductsDbContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("ProductsConnectionString"));
                })
             .AddScoped<IProductsRepository, ProductsRepository>();
    }
}