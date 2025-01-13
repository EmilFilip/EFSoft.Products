namespace EFSoft.Products.Domain.RepositoryContracts;

public interface IGetProductRepository
{
    Task<ProductDomainModel?> GetProductAsync(
          Guid productId,
          CancellationToken cancellationToken = default);
}
