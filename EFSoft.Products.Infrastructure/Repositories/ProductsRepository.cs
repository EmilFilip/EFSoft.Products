namespace EFSoft.Products.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ProductsDbContext _productsDbContext;

    public ProductsRepository(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public async Task CreateProductAsync(
        ProductModel product, 
        CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(product);

        _productsDbContext.Products.Add(entity);

        await _productsDbContext
            .SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteProductAsync(
        Guid productId, 
        CancellationToken cancellationToken = default)
    {
        var entity = await _productsDbContext.Products.FindAsync(
            keyValues: new object[] { productId },
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.Deleted = true;
            entity.DeletedAt = DateTime.UtcNow;

            _productsDbContext.Update(entity);
            await _productsDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<ProductModel>> GetProductsAsync(
        IEnumerable<Guid> productIds, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductModel> GetProductAsync(
        Guid productId, 
        CancellationToken cancellationToken = default)
    {
        var entity = await _productsDbContext.Products.FirstOrDefaultAsync(
            p => p.ProductId == productId && p.Deleted == false,
            cancellationToken: cancellationToken);

        if (entity == null)
        {
            return null;
        }

        return MapToDomain(entity);
    }

    public async Task UpdateProductAsync(
        ProductModel product, 
        CancellationToken cancellationToken = default)
    {
        var entity = await _productsDbContext.Products.FindAsync(
            keyValues: new object[] { product.ProductId },
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Description = product.Description;
            entity.InStock = product.InStock;

            _productsDbContext.Update(entity);
            await _productsDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    private static ProductModel MapToDomain(
        Product entityCustomer)
    {
        return new ProductModel(
            productId: entityCustomer.ProductId,
            description: entityCustomer.Description,
            inStock: entityCustomer.InStock);
    }

    private static Product MapToEntity(
        ProductModel domainCustomer)
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
