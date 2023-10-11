using Domain.Entities.Shop;

namespace Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task<Product> GetByIdAsync(int productId,CancellationToken cancellationToken);
    Task<Product> CreateProductAsync(Product product,CancellationToken cancellationToken);
    void UpdateProduct(Product product,CancellationToken cancellationToken);
    void DeleteProduct(Product product,CancellationToken cancellationToken);
    Task<Product> GetProductByTitleAsync(string title,CancellationToken cancellationToken);
    Task<bool> IsProductRegisteredAsync(string title,CancellationToken cancellationToken);
}