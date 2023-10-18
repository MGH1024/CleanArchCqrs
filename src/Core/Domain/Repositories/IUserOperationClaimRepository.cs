using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;

namespace Domain.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, int>, IRepository<UserOperationClaim, int> { }
