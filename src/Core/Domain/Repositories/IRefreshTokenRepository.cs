using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;

namespace Domain.Repositories;

public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken, int>, IRepository<RefreshToken, int> { }
