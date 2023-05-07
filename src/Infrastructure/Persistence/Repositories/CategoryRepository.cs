using Microsoft.EntityFrameworkCore;
using Domain.Entities.Shop;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllActiveAsync()
        {
            return await _appDbContext
                .Categories.Where(a => a.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllUpdatedAsync()
        {
            return await _appDbContext
                .Categories
                .Where(a => a.IsUpdated == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllDeletedAsync()
        {
            return await _appDbContext
                .Categories
                .Where(a => a.IsDeleted == true)
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _appDbContext
                .Categories
                .FirstOrDefaultAsync(a => a.Id == categoryId);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            return category;
        }

        public void UpdateCategory(Category category)
        {
            _appDbContext.Categories.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            _appDbContext.Categories.Remove(category);
        }

        public async Task<Category> GetCategoryByTitle(string title)
        {
            return await _appDbContext
                .Categories
                .Where(a => a.Title == title)
                .FirstAsync();
        }

        public async Task<bool> IsCategoryRegistered(string title)
        {
            return !await _appDbContext
                .Categories
                .AnyAsync(a => a.Title == title);
        }
    }
}