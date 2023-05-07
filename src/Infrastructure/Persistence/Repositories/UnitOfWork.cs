using Identity;
using Identity.Repositories;
using Microsoft.AspNetCore.Http;
using Application.Contracts.Infrastructure;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly AppIdentityDbContext _identityContext;
        private readonly IDateTime _dateTime;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UnitOfWork(AppDbContext context, AppIdentityDbContext identityContext,
            IHttpContextAccessor httpContextAccessor,
            ICategoryRepository categoryRepository, IUserRepository userRepository, IDateTime dateTime,
            IProductRepository productRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _identityContext = identityContext ?? throw new ArgumentNullException(nameof(identityContext));
            _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context);

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);


        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(_identityContext);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


        public async Task Save()
        {
            var username = "";
            if (_httpContextAccessor.HttpContext != null)
            {
                var name = _httpContextAccessor.HttpContext
                    .User
                    .Claims
                    .FirstOrDefault(x => x.Type.Equals("userName", StringComparison.InvariantCultureIgnoreCase));

                username = name == null ? "admin" : name.Value;
            }

            await _context.SaveChangesAsync(username, _dateTime.IranNow);
        }
    }
}