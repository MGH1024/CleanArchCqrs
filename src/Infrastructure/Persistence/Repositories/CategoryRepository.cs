using Microsoft.EntityFrameworkCore;
using Domain.Entities.Shop;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Categories.ToListAsync(cancellationToken);
        }

        public async Task<Category> GetByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .Categories
                .FirstOrDefaultAsync(a => a.Id == categoryId, cancellationToken);
        }

        public async Task<Category> CreateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            await _appDbContext.Categories.AddAsync(category, cancellationToken);
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

        public async Task<Category> GetCategoryByTitleAsync(string title,CancellationToken cancellationToken)
        {
            return await _appDbContext
                .Categories
                .Where(a => a.Title == title)
                .FirstAsync(cancellationToken);
        }

        public async Task<bool> IsCategoryRegisteredAsync(string title, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .Categories
                .AnyAsync(a => a.Title == title,cancellationToken);
        }
    }
}