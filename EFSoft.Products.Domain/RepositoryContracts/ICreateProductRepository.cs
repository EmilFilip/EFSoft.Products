namespace EFSoft.Products.Domain.RepositoryContracts;

public interface ICreateProductRepository
{
    Task CreateProductAsync(
        ProductDomainModel product,
        CancellationToken cancellationToken = default);
}
