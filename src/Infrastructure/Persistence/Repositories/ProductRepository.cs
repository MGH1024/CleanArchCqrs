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

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _appDbContext
            .Products
            .Include(a => a.Category)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product> GetByIdAsync(int productId, CancellationToken cancellationToken)
    {
        return await _appDbContext
            .Products
            .Include(a => a.Category)
            .FirstOrDefaultAsync(a => a.Id == productId,cancellationToken);
    }

    public async Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        await _appDbContext.Products.AddAsync(product,cancellationToken);
        return product;
    }

    public void UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        _appDbContext.Products.Update(product);
    }

    public void DeleteProduct(Product product, CancellationToken cancellationToken)
    {
        _appDbContext.Products.Remove(product);
    }

    public async Task<Product> GetProductByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _appDbContext
            .Products
            .Include(a => a.Category)
            .Where(a => a.Title == title)
            .FirstAsync(cancellationToken);
    }

    public async Task<bool> IsProductRegisteredAsync(string title, CancellationToken cancellationToken)
    {
        return !await _appDbContext
            .Products
            .AnyAsync(a => a.Title == title,cancellationToken);
    }
}