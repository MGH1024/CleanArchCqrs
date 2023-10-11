using Domain.Entities.Security;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<OperationClaim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
    {
        var result =  from opereationClaim in _appDbContext.OperationClaim
            join userOperationClaim in _appDbContext.UserOperationClaim
                on opereationClaim.Id equals userOperationClaim.OperationClaimId
            where userOperationClaim.UserId == user.Id
            select new OperationClaim { Id = opereationClaim.Id, Name = opereationClaim.Name };
        return await result.ToListAsync();
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _appDbContext.User.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<User> GetByMailAsync(string email, CancellationToken cancellationToken)
    {
        return await _appDbContext.User.FirstOrDefaultAsync(a => a.Email == email);
    }
}