﻿using Microsoft.AspNetCore.Http;
using Application.Interfaces;
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
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UnitOfWork(AppDbContext context,
            IHttpContextAccessor httpContextAccessor,
            ICategoryRepository categoryRepository, IUserRepository userRepository, IDateTime dateTime,
            IProductRepository productRepository)
        {
            _context = context;
            _dateTime = dateTime;
            _httpContextAccessor = httpContextAccessor;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context);

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);

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