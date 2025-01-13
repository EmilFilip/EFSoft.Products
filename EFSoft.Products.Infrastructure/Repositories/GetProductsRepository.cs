namespace EFSoft.Products.Infrastructure.Repositories;

public class GetProductsRepository(ProductsDbContext productsDbContext) : IGetProductsRepository
{
    public async Task<IEnumerable<ProductDomainModel>> GetProductsAsync(
        IEnumerable<Guid> productIds,
        CancellationToken cancellationToken = default)
    {
        var entities = await productsDbContext.Products
            .AsQueryable()
            .Where(c => productIds.Contains(c.ProductId) && c.Deleted == false)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return entities.Select(x => MapToDomain(x));
    }

    private static ProductDomainModel MapToDomain(
    Product entityCustomer)
    {
        return new ProductDomainModel(
            productId: entityCustomer.ProductId,
            description: entityCustomer.Description,
            inStock: entityCustomer.InStock);
    }
}
