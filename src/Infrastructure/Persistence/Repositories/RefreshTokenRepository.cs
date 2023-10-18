

using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, DbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(DbContext context)
        : base(context) { }
}
