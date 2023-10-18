using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, int, DbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(DbContext context)
        : base(context) { }
}
