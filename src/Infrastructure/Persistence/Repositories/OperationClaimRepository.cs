using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, AppDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(AppDbContext context)
        : base(context) { }
}
