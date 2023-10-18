using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;

namespace Domain.Repositories;

public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int> { }
