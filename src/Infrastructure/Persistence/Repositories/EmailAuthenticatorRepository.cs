using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, int, DbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(DbContext context)
        : base(context) { }
}
