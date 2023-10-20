using Microsoft.AspNetCore.Http;
using Application.Interfaces.Public;
using Application.Interfaces.UnitOfWork;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IDateTime _dateTime;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private IOperationClaimRepository _operationClaimRepository;
        private IOtpAuthenticatorRepository _otpAuthenticatorRepository;
        private IRefreshTokenRepository _refreshTokenRepository;
        private IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitOfWork(AppDbContext context,
            IHttpContextAccessor httpContextAccessor,
            ICategoryRepository categoryRepository,
            IDateTime dateTime,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IEmailAuthenticatorRepository emailAuthenticatorRepository, 
            IOperationClaimRepository operationClaimRepository,
            IOtpAuthenticatorRepository otpAuthenticatorRepository, 
            IRefreshTokenRepository refreshTokenRepository, 
            IUserOperationClaimRepository userOperationClaimRepository)
        {
            _context = context;
            _dateTime = dateTime;
            _httpContextAccessor = httpContextAccessor;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _operationClaimRepository = operationClaimRepository;
            _otpAuthenticatorRepository = otpAuthenticatorRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context);

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);
        
        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(_context);
        
        public IEmailAuthenticatorRepository EmailAuthenticatorRepository =>
            _emailAuthenticatorRepository ??= new EmailAuthenticatorRepository(_context);
        
        public IOperationClaimRepository OperationClaimRepository =>
            _operationClaimRepository ??= new OperationClaimRepository(_context);
        
        public IOtpAuthenticatorRepository OtpAuthenticatorRepository =>
            _otpAuthenticatorRepository ??= new OtpAuthenticatorRepository(_context);
        
        public IRefreshTokenRepository RefreshTokenRepository =>
            _refreshTokenRepository ??= new RefreshTokenRepository(_context);
        
        public IUserOperationClaimRepository UserOperationClaimRepository =>
            _userOperationClaimRepository ??= new UserOperationClaimRepository(_context);
        

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


        public async Task SaveChangeAsync(CancellationToken cancellationToken)
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

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}