namespace EFSoft.Products.Domain.RepositoryContracts;

public interface IGetProductsRepository
{
    Task<IEnumerable<ProductDomainModel>> GetProductsAsync(
          IEnumerable<Guid> productIds,
          CancellationToken cancellationToken = default);
}
