using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, AppDbContext>,
    IUserOperationClaimRepository
{
    public UserOperationClaimRepository(AppDbContext context)
        : base(context)
    {
    }
}