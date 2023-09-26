using EFSoft.Products.Domain.Models;

namespace EFSoft.Products.Domain.RepositoryContracts;

public interface IProductsRepository
{
    Task<ProductModel> GetProductAsync(
              Guid productId,
              CancellationToken cancellationToken = default);

    Task<IEnumerable<ProductModel>> GetProductsAsync(
          IEnumerable<Guid> productIds,
          CancellationToken cancellationToken = default);

    Task CreateProductAsync(
        ProductModel product,
        CancellationToken cancellationToken = default);

    Task UpdateProductAsync(
        ProductModel product,
        CancellationToken cancellationToken = default);

    Task DeleteProductAsync(
        Guid productId,
        CancellationToken cancellationToken = default);
}
