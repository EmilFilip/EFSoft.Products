namespace EFSoft.Products.Infrastructure.Repositories;

public class GetProductRepository(ProductsDbContext productsDbContext) : IGetProductRepository
{
    public async Task<ProductDomainModel?> GetProductAsync(
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        var entity = await productsDbContext.Products
            .AsQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(p =>
                    p.ProductId == productId && p.Deleted == false,
                    cancellationToken: cancellationToken);

        if (entity == null)
        {
            return null;
        }

        return MapToDomain(entity);
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
