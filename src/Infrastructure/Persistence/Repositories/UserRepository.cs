using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, int, DbContext>, IUserRepository
{
    public UserRepository(DbContext context)
        : base(context)
    {
    }
}