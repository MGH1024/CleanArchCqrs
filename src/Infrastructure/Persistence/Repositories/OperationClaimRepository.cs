using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, DbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(DbContext context)
        : base(context) { }
}
