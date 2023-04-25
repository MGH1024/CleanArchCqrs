using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IDateTime _dateTime;
        private ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor,
            ICategoryRepository categoryRepository, IUserRepository userRepository, IDateTime dateTime)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        

        public async Task Save()
        {
            var username = "";
            var name = _httpContextAccessor.HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type.Equals("userName", StringComparison.InvariantCultureIgnoreCase));

            username = name == null ? "admin" : name.Value;

            await _context.SaveChangesAsync(username,_dateTime.IranNow);
        }
    }
}