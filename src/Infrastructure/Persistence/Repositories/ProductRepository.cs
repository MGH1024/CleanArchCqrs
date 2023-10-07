using Domain.Entities.Shop;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _appDbContext
            .Products
            .Include(a => a.Category)
            .ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int productId)
    {
        return await _appDbContext
            .Products
            .Include(a => a.Category)
            .FirstOrDefaultAsync(a => a.Id == productId);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await _appDbContext.Products.AddAsync(product);
        return product;
    }

    public void UpdateProduct(Product product)
    {
        _appDbContext.Products.Update(product);
    }

    public void DeleteProduct(Product product)
    {
        _appDbContext.Products.Remove(product);
    }

    public async Task<Product> GetProductByTitle(string title)
    {
        return await _appDbContext
            .Products
            .Include(a => a.Category)
            .Where(a => a.Title == title)
            .FirstAsync();
    }

    public async Task<bool> IsProductRegistered(string title)
    {
        return !await _appDbContext
            .Products
            .AnyAsync(a => a.Title == title);
    }
}