using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, int, AppDbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(AppDbContext context)
        : base(context) { }
}
