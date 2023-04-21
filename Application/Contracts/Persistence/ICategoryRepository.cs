using Domain.Shop;

namespace Application.Contracts.Persistence;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<IEnumerable<Category>> GetAllActiveAsync();
    Task<IEnumerable<Category>> GetAllUpdatedAsync();
    Task<IEnumerable<Category>> GetAllDeletedAsync();
    Task<Category> GetByIdAsync(int categoryId);
    Task<Category> CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
    Task<Category> GetCategoryByTitle(string title);
    Task<bool> IsCategoryRegistered(string title);
}