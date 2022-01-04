namespace EFSoft.Products.Infrastructure.DBContexts;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
