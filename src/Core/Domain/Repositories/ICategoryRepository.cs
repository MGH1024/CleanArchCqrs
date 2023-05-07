using Domain.Entities.Shop;

namespace Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<IEnumerable<Category>> GetAllActiveAsync();
    Task<IEnumerable<Category>> GetAllUpdatedAsync();
    Task<IEnumerable<Category>> GetAllDeletedAsync();
    Task<Category> GetByIdAsync(int categoryId);
    Task<Category> CreateCategoryAsync(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);
    Task<Category> GetCategoryByTitle(string title);
    Task<bool> IsCategoryRegistered(string title);
}