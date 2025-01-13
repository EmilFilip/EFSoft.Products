namespace EFSoft.Products.Infrastructure.Repositories;

public class CreateProductRepository(ProductsDbContext productsDbContext) : ICreateProductRepository
{
    public async Task CreateProductAsync(
        ProductDomainModel product,
        CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(product);

        _ = productsDbContext.Products.Add(entity);

        _ = await productsDbContext
            .SaveChangesAsync(cancellationToken);
    }

    private static Product MapToEntity(
        ProductDomainModel domainCustomer)
    {
        return new Product
        {
            ProductId = domainCustomer.ProductId,
            Description = domainCustomer.Description,
            InStock = domainCustomer.InStock,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
