using Domain.Entities.Shop;

namespace Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
    Task<Category> GetByIdAsync(int categoryId,CancellationToken cancellationToken);
    Task<Category> CreateCategoryAsync(Category category, CancellationToken cancellationToken);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);
    Task<Category> GetCategoryByTitleAsync(string title,CancellationToken cancellationToken);
    Task<bool> IsCategoryRegisteredAsync(string title,CancellationToken cancellationToken);
}