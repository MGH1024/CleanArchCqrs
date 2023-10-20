using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, AppDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDbContext context)
        : base(context) { }
}
