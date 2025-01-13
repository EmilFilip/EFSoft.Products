namespace EFSoft.Products.Infrastructure.Repositories;

public class DeleteProductRepository(ProductsDbContext productsDbContext) : IDeleteProductRepository
{
    public async Task DeleteProductAsync(
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        var entity = await productsDbContext.Products.FindAsync(
            keyValues: [productId],
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.Deleted = true;
            entity.DeletedAt = DateTime.UtcNow;

            _ = productsDbContext.Update(entity);
            _ = await productsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
