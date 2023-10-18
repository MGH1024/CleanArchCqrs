using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, DbContext>,
    IUserOperationClaimRepository
{
    public UserOperationClaimRepository(DbContext context)
        : base(context)
    {
    }
}