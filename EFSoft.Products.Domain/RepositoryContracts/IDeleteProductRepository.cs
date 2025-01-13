namespace EFSoft.Products.Domain.RepositoryContracts;

public interface IDeleteProductRepository
{
    Task DeleteProductAsync(
    Guid productId,
    CancellationToken cancellationToken = default);
}
