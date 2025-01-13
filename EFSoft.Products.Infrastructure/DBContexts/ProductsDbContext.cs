namespace EFSoft.Products.Infrastructure.DBContexts;

public class ProductsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
