namespace EFSoft.Products.Infrastructure.Repositories;

public class UpdateProductRepository(ProductsDbContext productsDbContext) : IUpdateProductRepository
{
    public async Task UpdateProductAsync(
        ProductDomainModel product,
        CancellationToken cancellationToken = default)
    {
        var entity = await productsDbContext.Products.FindAsync(
            keyValues: [product.ProductId],
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Description = product.Description;
            entity.InStock = product.InStock;

            _ = productsDbContext.Update(entity);
            _ = await productsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
