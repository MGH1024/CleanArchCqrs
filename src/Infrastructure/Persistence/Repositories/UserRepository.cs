using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, int, AppDbContext>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }
}