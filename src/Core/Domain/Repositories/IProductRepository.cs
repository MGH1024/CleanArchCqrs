using Domain.Entities.Shop;

namespace Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> GetAllActiveAsync();
    Task<IEnumerable<Product>> GetAllUpdatedAsync();
    Task<IEnumerable<Product>> GetAllDeletedAsync();
    Task<Product> GetByIdAsync(int productId);
    Task<Product> CreateProductAsync(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    Task<Product> GetProductByTitle(string title);
    Task<bool> IsProductRegistered(string title);
}