namespace EFSoft.Products.Domain.RepositoryContracts;

public interface IUpdateProductRepository
{
    Task UpdateProductAsync(
        ProductDomainModel product,
        CancellationToken cancellationToken = default);
}
