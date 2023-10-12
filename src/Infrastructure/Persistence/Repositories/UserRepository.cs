﻿using Domain.Entities.Security;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Role>> GetClaimsAsync(User user, CancellationToken cancellationToken)
    {
        var result =  from opClaim in _appDbContext.OperationClaim
            join userOperationClaim in _appDbContext.UserOperationClaim
                on opClaim.Id equals userOperationClaim.RoleId
            where userOperationClaim.UserId == user.Id
            select new Role { Id = opClaim.Id, Title = opClaim.Title };
        return await result.ToListAsync( cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _appDbContext.User.AddAsync(user, cancellationToken);
    }

    public async Task<User> GetByMailAsync(string email, CancellationToken cancellationToken)
    {
        return await _appDbContext.User.FirstOrDefaultAsync(a => a.Email == email,  cancellationToken);
    }
}